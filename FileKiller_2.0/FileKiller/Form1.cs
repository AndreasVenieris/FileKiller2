/*
 * File Killer Commercial Edition.
 * Permanent deletion of files.
 * © by Andreas Venieris 2012,2016.
 * Developed in C# - VS 2015.
 * 
 * -------------------------------------------------------------------------------------------------
 * Version 2.0 - GNU General License
 **********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

delegate void UpdateDVGrid_Delegate(int n, string sErrMsg);

namespace FileKiller
{

    public partial class Form1 : Form
    {
        private int rowIndexOfItemUnderMouseToDrop;
        private int dataGridView1_row = -1;
        private volatile bool bStopTheThread = false;
        private volatile bool bCurrentThreadRunning = false;
        private int iNumberOfFilesProcessed = 0;

        #region Form1 Events

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //String[] arguments = Environment.GetCommandLineArgs();
            //string args = String.Join(" ", arguments);
            string args = Environment.CommandLine;
            args = args.Substring(args.IndexOf(" "));

            // Set Parameters from Registry (if exist)
            if (Microsoft.Win32.Registry.CurrentUser.GetValue("FileKiller") == null)
            {
                // READ REG VALUES IF EXIST.
                Microsoft.Win32.RegistryKey key;

                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("FileKiller");
                if (key != null)
                {
                    string sIterations = key.GetValue("Iterations").ToString();
                    if (sIterations != null)
                        numericUpDown1.Value = Convert.ToInt32(sIterations);

                    string sFillWith = key.GetValue("FillWith").ToString();
                    if (sFillWith != null)
                    {
                        if (sFillWith == radioButton_RandomData.Text)
                            radioButton_RandomData.Checked = true;
                        else if (sFillWith == radioButton_Blanks.Text)
                            radioButton_Blanks.Checked = true;
                        else if (sFillWith == radioButton_ASCII.Text)
                        {
                            radioButton_ASCII.Checked = true;

                            string sASCII = key.GetValue("ASCII").ToString();
                            if (sASCII != null)
                            {
                                numericUpDown2.Text = sASCII;
                            }
                        }

                    }//end if

                    string sIncludeSubdirectories = key.GetValue("IncludeSubdirectories").ToString();
                    if (sIncludeSubdirectories != null)
                        checkBox_includeSubDirs.Checked = (sIncludeSubdirectories == "True")?true:false;


                    string sDataBuffer = key.GetValue("DataBuffer").ToString();
                    if (sDataBuffer != null)
                        tbx_DataBuffer.Text = sDataBuffer;
                    key.Close();
                }

            }


            // Get filename from command line (ex: after right click on a file)
            if (args.Length > 1)
            {
                ////////////////////////////////////////////////////////////////////
                string filename;

                Boolean bFileAlreadyExistInGrid = false;
                filename = args;

                // Insert it into the Grid if not exist.
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (filename == (string)dataGridView1.Rows[j].Cells["Column_Filename"].Value)
                    {
                        bFileAlreadyExistInGrid = true;
                        break;
                    }
                }
                if (!bFileAlreadyExistInGrid)
                    dataGridView1.Rows.Add("File", args);
            }
            updateStatusLine();
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                insertSelectedFilesIntoArray(openFileDialog1.FileNames);
            }
        }

        private void insertSelectedFilesIntoArray(string[] filenames)
        {
            string filename;
            bool bFileAlreadyExistInGrid = false;

            for (int i = 0; i < filenames.Length; i++)
            {
                bFileAlreadyExistInGrid = false;
                filename = filenames[i];

                // Insert it into the Grid if not exist.
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (filename == (string)dataGridView1.Rows[j].Cells[1].Value)
                    {
                        bFileAlreadyExistInGrid = true;
                        break;
                    }
                }
                if (bFileAlreadyExistInGrid)
                    continue;

                // Define the new row to the grid view and add it.
                string[] row = new string[] { "", "", "", "" };
                row[0] = "File";    // FileType
                row[1] = filename;  // Filename
                row[2] = "";        // Error
                dataGridView1.Rows.Add(row);
            }

            updateStatusLine();
        }

        private void button_ClearGrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.Columns["Info"].Visible = false;
            updateStatusLine();
        }

        private void Button_KillFiles_Click(object sender, EventArgs e)
        {

            if (bCurrentThreadRunning)
            {
                MessageBox.Show("The current thread is still running. Cancel it or wait to finish please.", "Oopps!");
                return;
            }

            string sDataBuffer = tbx_DataBuffer.Text.Replace(".", "").Replace(",", "");
            int NumInt;

            bool isDatabufferNumber = int.TryParse(sDataBuffer, out NumInt);


            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There are no files to delete. The grid is empty.", "Oopps!");
            }
            else if (!isDatabufferNumber)
            {
                MessageBox.Show("Invalid Data Buffer defined in Options Tab. Please Correct.", "Oopps!");
            }
            else if (Convert.ToInt32(sDataBuffer) < 1)
            {
                MessageBox.Show("Too low Data Buffer defined in Options Tab. Please Correct.", "Oopps!");
            }
            else if (MessageBox.Show("Are you sure you want to permanently delete the files in the grid ?",
                                     "Delete for ever!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                // Start the thread to delete files!
                Thread workerThread = new Thread(delegate()
                                                {
                                                    killTheFiles();
                                                });
                workerThread.Start();
                this.bCurrentThreadRunning = true;

                //workerThread.Join();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateStatusLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About1 about = new About1();
            about.ShowDialog();
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1_row = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            }

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;

                string filename;
                string[] fileNames;
                fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                int iNumOfFilesSelected = fileNames.Count();
                bool bFileAlreadyExistInGrid;

                for (int i = 0; i < iNumOfFilesSelected; i++)
                {
                    bFileAlreadyExistInGrid = false;
                    filename = fileNames[i];

                    FileAttributes attr = File.GetAttributes(@filename);

                    //detect whether its a directory or file
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        FillGridFromDir(@filename);
                        continue; // Get next file/dir
                    }
                    else
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            if (filename == (string)dataGridView1.Rows[j].Cells["Column_Filename"].Value)
                            {
                                bFileAlreadyExistInGrid = true;
                                break;
                            }
                        }
                    }
                    if (bFileAlreadyExistInGrid)
                        continue; // Get next file/dir

                    string[] row = new string[] { "", "", "", "" };
                    row[0] = (((attr & FileAttributes.Directory) == FileAttributes.Directory) ? "DIR" : "File");  // Type 
                    row[1] = filename;  // Filename
                    row[2] = "";        // Error
                    dataGridView1.Rows.Add(row);
                }

                updateStatusLine();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_SelectDirs_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            FillGridFromDir(fbd.SelectedPath);

        }

        private void Btn_CancelAction_Click(object sender, EventArgs e)
        {
            this.bStopTheThread = true;
            this.bCurrentThreadRunning = false;
        }

        #endregion  ////////////////////////////////////////////////////////////////////////////////

        #region Form1 Members
        /// <summary>
        /// Kill the current set of files.
        /// </summary>
        /// <param name="iDataBuffer"></param>
        private void killTheFiles()
        {

            int i = 0;
            while (true)
            {
                string FileDir = "";
                string filename = "";

                try
                {
                    FileDir = (string)dataGridView1.Rows[i].Cells["FileDir"].Value;
                    filename = (string)dataGridView1.Rows[i].Cells["Column_Filename"].Value;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    break;
                }

                string sInfoResult = "KILLED!";

                if (FileDir == "File")
                {
                    // Just kill the file
                     killFile(filename, i, -1, -1, out sInfoResult);

                    if (bStopTheThread)
                        break;
                }
                else if (FileDir == "DIR")
                {
                    // Get All files from this directory into 'files'
                    string[] files = Directory.GetFiles(@filename, "*.*",
                                            (checkBox_includeSubDirs.Checked == true)
                                            ? SearchOption.AllDirectories
                                            : SearchOption.TopDirectoryOnly);

                    // Navigate all the files in the DIR and try to kill them.
                    //foreach (string fname in files)
                    int n, numOfFilesInDir = files.Count();
                    for (n=0; n < numOfFilesInDir; n++)
                    {
                        killFile(files[n], i, n+1, numOfFilesInDir, out sInfoResult);

                        if (bStopTheThread)
                            break; 

                        if (sInfoResult != "KILLED!")
                            sInfoResult = "Erros encountered while killing the files! Please Check mannually.";
                    }
                }
                if (bStopTheThread)
                    break;

                // Update the current processed files variable.
                this.iNumberOfFilesProcessed++;

                // Communicate with the grid to inform the user.
                object[] oArgs = new object[2];
                oArgs[0] = i;
                oArgs[1] = sInfoResult;

                UpdateDVGrid_Delegate handler = UpdateGridFromThread;
                dataGridView1.BeginInvoke(handler, oArgs);
                i++;
            }
            // Thread Termination
            updateStatusLine();
            string msg = (bStopTheThread) ? "Process Canceled!" : "End of process!";
            initialize_state();
            MessageBox.Show(msg,
                            "Process Terminate",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        /// <summary>
        /// Initialize Form1 variables
        /// </summary>
        private void initialize_state()
        {
            this.bStopTheThread = false;
            this.bCurrentThreadRunning = false;
            this.iNumberOfFilesProcessed = 0;

            // Clear the Proces Flag of each Line.
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells["Processed"].Value = "";
        }

        /// <summary>
        /// Reference function to update Datagredview from a thread via a delegate
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sErrMsg"></param>
        private void UpdateGridFromThread(int n, string sMsg)
        {
            try
            {
                //dataGridView1.Rows.RemoveAt(n);
                dataGridView1.Rows[n].Cells["Info"].Value = sMsg;
                dataGridView1.Rows[n].Cells["Processed"].Value = "1";
            }
            catch (System.ArgumentOutOfRangeException)
            {
                //iNumberOfFilesProcessed--;
            }
            finally
            {
                //iNumberOfFilesProcessed++;
            }
            updateStatusLine();

        }

        /// <summary>
        /// Update Status
        /// </summary>
        private void updateStatusLine()
        {
            double perc = 0;
            if (dataGridView1.Rows.Count>0)
                perc = (100 * this.iNumberOfFilesProcessed) / dataGridView1.Rows.Count;

            label_NumOfFiles.Text = dataGridView1.Rows.Count.ToString()+
                                    "    Processed: " + this.iNumberOfFilesProcessed.ToString() +
                                    "    Completed: " + perc.ToString() + "%";
        }


        /// <summary>
        /// Kill the Current file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="atLine"></param>
        /// <param name="iDirCurrent"></param> In case of Directory this is the current file no, otherwise -1.
        /// <param name="ofAll"></param> In case of Directory this is the number all files,  otherwise -1.
        /// <returns></returns>
        private int killFile(string filename, int atLine, int iDirCurrent, int iDirAll, out string MsgResult)
        {
            lock (this)
            {
                // Object used to pass arguments into the GridView.
                object[] oArgs = new object[2];

                // Get the current databuffer defined in setting.
                int NumInt;
                string sDataBuffer = tbx_DataBuffer.Text.Replace(".", "").Replace(",", "");
                bool isDatabufferNumber = int.TryParse(sDataBuffer, out NumInt);
                if (!isDatabufferNumber)
                {
                    MsgResult = "Invalid DataBuffer defined in settings. Please redefine!";
                    return -1;
                }
                int iDataBuffer = Convert.ToInt32(sDataBuffer);

                // Check if the user Canceled the action.
                if (bStopTheThread)
                {
                    Cursor.Current = Cursors.Default;
                    MsgResult = "";
                    return 1;
                }

                // Update the currect line about the start of process.
                oArgs[0] = atLine;
                oArgs[1] = "Killing...";
                UpdateDVGrid_Delegate handler = UpdateGridFromThread;
                dataGridView1.BeginInvoke(handler, oArgs);

                /// !!!!!!!!!!!  FOR DEBUG ONLY !!!!!!!!!!!!!!!!!!!!
                //System.Threading.Thread.Sleep(3000);
                //return "KILLED!"; //aaa
                /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                MsgResult = "KILLED!";
                int Ret = 1;
                try
                {
                    byte[] rowDataBuffer;

                    // Define the stream buffer to read in times of Kbytes.
                    int iBufferLength = iDataBuffer * 1024;

                    // I open a stream w/o the fileshare flag defined. This declines sharing of the current file. 
                    // Any request to open the file (by this process or another process) will fail until 
                    // the file is closed.
                    using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                    {

                        Cursor.Current = Cursors.WaitCursor;

                        FileInfo f = new FileInfo(filename);
                        long count = f.Length;
                        long offset = 0;
                        rowDataBuffer = new byte[iBufferLength];

                        if (iBufferLength == 0)
                        {
                            Cursor.Current = Cursors.Default;
                            MsgResult = "Invalid DataBuffer defined in settings. Please redefine!";
                            return -2;
                        }

                        // Calculate the number of passes needed inside the file.
                        long iNumOfBufferReads = (f.Length / iBufferLength) + ((f.Length % iBufferLength == 0) ? 0 : 1);

                        int iCurrentBufferRead = 0; // Current Step inside the file
                        while (count >= 0) // While the Buffer read is lower than the File.Length
                        {
                            iCurrentBufferRead++;

                            if (bStopTheThread)
                            {
                                Cursor.Current = Cursors.Default;
                                MsgResult = "";
                                return 1;
                            }

                            int iNumOfDataRead = stream.Read(rowDataBuffer, 0, iBufferLength);
                            // I have inside the rowDataBuffer array the contents of a fragment of the file.
                            if (iNumOfDataRead == 0)
                            {
                                break;
                            }
                            // I will apply the transformations to the rowDataBuffer array and then i will 
                            // write it back to the file.
                            if (radioButton_RandomData.Checked)
                            {
                                Random randombyte = new Random();
                                randombyte.NextBytes(rowDataBuffer);
                            }
                            else if (radioButton_Blanks.Checked)
                            {
                                for (int i = 0; i < iNumOfDataRead; i++)
                                    rowDataBuffer[i] = 0;
                            }
                            else
                            {
                                for (int i = 0; i < iNumOfDataRead; i++)
                                    rowDataBuffer[i] = Convert.ToByte(Convert.ToChar(Convert.ToInt32(numericUpDown2.Value)));
                            }
                            // Write the new contents back to the file <n> times.
                            string sMsg = "";
                            for (int i = 0; i < numericUpDown1.Value; i++)
                            {
                                stream.Seek(offset, SeekOrigin.Begin);
                                stream.Write(rowDataBuffer, 0, iNumOfDataRead);

                                //sMsg = "Killing [%{0}]...Buffer {1}/{2}, Write {3} of {4}...";
                                //sMsg = string.Format(sMsg,
                                //                       (((iCurrentBufferRead + i+1) * 100) / (iNumOfBufferReads + numericUpDown1.Value)).ToString("F02"),
                                //                       iCurrentBufferRead,
                                //                       iNumOfBufferReads,
                                //                       i+1,
                                //                       numericUpDown1.Value
                                //                      );
                                //dataGridView1.Rows[atLine].Cells["Info"].Value = sMsg;

                            }
                            if (iDirCurrent == -1) // The Caller is a single file.
                            {
                                sMsg = "Killing [%{0}]...Buffer {1}/{2}, Write {3} times...";
                                sMsg = string.Format(sMsg,
                                                       (((iCurrentBufferRead + numericUpDown1.Value + 1) * 100) / (iNumOfBufferReads + numericUpDown1.Value)).ToString("F0"),
                                                       iCurrentBufferRead,
                                                       iNumOfBufferReads,
                                                       numericUpDown1.Value
                                                      );
                            }
                            else // The Caller is a Directory.
                            {
                                sMsg = "Killing {0}/{1} [%{2}]...Buffer {3}/{4}, Write {5} times...";
                                sMsg = string.Format(sMsg,
                                                       iDirCurrent,
                                                       iDirAll,
                                                       (((iDirCurrent + 1) * 100) / (iDirAll)).ToString("F0"),
                                                       iCurrentBufferRead,
                                                       iNumOfBufferReads,
                                                       numericUpDown1.Value
                                                      );

                            }
                            dataGridView1.Rows[atLine].Cells["Info"].Value = sMsg;

                            // Calculate the new offset & count
                            offset += iNumOfDataRead;
                            count -= iNumOfDataRead;
                        } //while
                    } // using

                    // Substitude every filename character with random numbers from 0 to 9.
                    string newName = "";
                    do
                    {
                        Random random = new Random();
                        string cleanName = Path.GetFileName(filename);
                        string dirName = Path.GetDirectoryName(filename);

                        int iMoreRandomLetters = random.Next(9);
                        // for more security, don't use only the size of the original filename but add some random letter.
                        for (int i = 0; i < cleanName.Length + iMoreRandomLetters; i++)
                        {
                            newName += random.Next(9).ToString();
                        }
                        newName = dirName + "\\" + newName;
                    } while (File.Exists(newName));

                    //Rename the file to the new random name.
                    File.Move(filename, newName);

                    //Delete the file now.
                    File.Delete(newName);

                }
                catch (Exception e)
                {
                    MsgResult = e.Message;
                    Ret = -3;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                return Ret;
            }//end lock
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label_letter.Text = Convert.ToChar(Convert.ToInt32(numericUpDown2.Value)).ToString();
        }

        private void radioButton_ASCII_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = radioButton_ASCII.Checked;
            label_letter.Enabled = radioButton_ASCII.Checked;
        }

        private void FillGridFromDir(string sDir)
        {
            if (sDir.Length == 0)
            {
                return;
            }

            // Insert it into the Grid if not exist.
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                if ("DIR" == (string)dataGridView1.Rows[j].Cells["FileDir"].Value &&
                     sDir == (string)dataGridView1.Rows[j].Cells["Column_Filename"].Value
                   )
                    return;

            string[] row = new string[] { "", "", "", "" };
            row[0] = "DIR";    // FileType
            row[1] = sDir;     // Filename
            row[2] = "";       // Error
            dataGridView1.Rows.Add(row);
        }

        #endregion ////////////////////////////////////////////////////////////////////////////////

        private void toolStripMenuItem1_excludeLine_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1_row > -1)
            {
                if (bCurrentThreadRunning &&
                    (string)dataGridView1.Rows[this.dataGridView1_row].Cells["Processed"].Value == "1"
                   )
                {
                    MessageBox.Show("You cannot exclude an already process line while a killing action is running.", "Oopps!");
                    return;
                }

                dataGridView1.Rows.RemoveAt(this.dataGridView1_row);
                updateStatusLine();
            }
        }

        private void btn_SaveParams_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("FileKiller");
            key.SetValue("Iterations", numericUpDown1.Value.ToString());

            if (radioButton_RandomData.Checked)
                key.SetValue("FillWith", radioButton_RandomData.Text);
            else if (radioButton_Blanks.Checked)
                key.SetValue("FillWith", radioButton_Blanks.Text);
            else if (radioButton_ASCII.Checked)
            {
                key.SetValue("FillWith", radioButton_ASCII.Text);
                key.SetValue("ASCII", numericUpDown2.Value.ToString());
            }
            key.SetValue("IncludeSubdirectories", checkBox_includeSubDirs.Checked.ToString());
            key.SetValue("DataBuffer", tbx_DataBuffer.Text);
            key.Close();
            MessageBox.Show("Parameters saved to Registry.", "Message");

        }


    }


} // END OF NAMESPACE

