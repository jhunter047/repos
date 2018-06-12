using System;
using System.Drawing;
using System.Windows.Forms;
using System.Management; 
using System.Threading;


/// <summary>
/// Program which displays a HDD indicator while the HDD is in use. 
/// </summary>


namespace HDD_Activity
{

    /// <summary>
    /// Main function
    /// </summary>
    public partial class Form1 : Form
    {
        NotifyIcon hddLedIcon;
        Icon activeIcon;
        Icon idleIcon;
        Thread hddLedworker;

        public Form1()
        {



            InitializeComponent();


            //load icons from file
            activeIcon = new Icon("HDD_Busy.ico");
            idleIcon = new Icon("HDD_Idle.ico");

            //create notify icons and asign idle icon
            hddLedIcon = new NotifyIcon();
            hddLedIcon.Icon = idleIcon;
            hddLedIcon.Visible = true;


            //create all context menu items and add them to the tray icon 
            MenuItem progNameMenuItem = new MenuItem("HDD Activity v1 by Joe Hunter");
            MenuItem quitMenuItem = new MenuItem("Quit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(progNameMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);

            //MenuItem date = new MenuItem(DateTime.Now.ToString("h:mm:ss tt"));
            //contextMenu.MenuItems.Add(date);

            hddLedIcon.ContextMenu = contextMenu;

            //Quit button code
            quitMenuItem.Click += QuitMenuItem_Click;


            //on start minimise the program and do not show in the taskbar
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //start hard drive thread that pulls worker activity
            hddLedworker = new Thread(new ThreadStart(hddActivityThread));
            hddLedworker.Start();

        }

        /// <summary>
        /// close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            hddLedworker.Abort();
            hddLedIcon.Dispose();
            this.Close();
        }

        //this is the thread that 
        public void hddActivityThread()
        {


            try
            {
                ManagementClass driveDataClass = new ManagementClass("Win32_perfFormattedData_PerfDisk_PhysicalDisk");


                while (true)
                {
                    ManagementObjectCollection driveDataClassCollection = driveDataClass.GetInstances();
                    foreach (ManagementObject obj in driveDataClassCollection)
                    {
                        if (obj["Name"].ToString() == "_Total")
                        {
                            if (Convert.ToUInt64(obj["DiskBytesPersec"]) > 0)
                            {
                                //show busy icon
                                hddLedIcon.Icon = activeIcon;
                            }
                            else
                            {
                                //show idle icon
                                hddLedIcon.Icon = idleIcon;
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
            catch (ThreadAbortException tbe)
            {

            }

        }
    }
}





