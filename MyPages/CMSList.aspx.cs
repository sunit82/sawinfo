using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Net.Mail;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using SAWDAL;

namespace MyPages
{
    public partial class CMSList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Administrator"))
            {
                Response.Redirect("Login.aspx");
            }
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                GetList();
                ServiceController svcController = new ServiceController("WinSrvSAW");
                try
                {
                    if (svcController != null)
                    {
                        lblServiceStatus.Text = svcController.Status.ToString();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        private void GetList()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> lstSP = new List<SqlParameter>();
            ds = SAWDB.GetDataset("SAW_GetCMSList", CommandType.StoredProcedure,
                lstSP);
            gvPageList.DataSource = ds;
            gvPageList.DataBind();
        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            Session["CMS_Page_Edit"] = null;
            Response.Redirect("CMSEdit.aspx");
        }

        protected void gvPageList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmsEdit")
            {
                Session["CMS_Page_Edit"] = e.CommandArgument.ToString();
                Response.Redirect("CMSEdit.aspx");
            }
            else if (e.CommandName == "cmsDelete")
            {
                List<SqlParameter> lstSP = new List<SqlParameter>();
                lstSP.Add(new SqlParameter("@PageId", e.CommandArgument.ToString()));

                int rec = SAWDB.Excecute("SAW_CMSDelete", CommandType.StoredProcedure, lstSP);
                if (rec > 0)
                {
                    lblMessage.Text = "Record Deleted Successfully";
                    GetList();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void lnkAdminConsole_Click(object sender, EventArgs e)
        {
            Response.Redirect("CMSUserMembership.aspx");

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        protected void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //Installs and starts the service 
                ServiceInstaller.InstallAndStart("WinSrvSAW", "WinSrvSAW", this.Server.MapPath("TestWinSer.exe"));
                ServiceController svcController = new ServiceController("WinSrvSAW");
                if (svcController != null)
                {
                    lblServiceStatus.Text = svcController.Status.ToString();
                }
                //Removes the service ServiceInstaller.Uninstall("WinSrvSAW");  //Checks the status of the service ServiceInstaller.GetServiceStatus("WinSrvSAW");  //Starts the service ServiceInstaller.StartService("WinSrvSAW");  //Stops the service ServiceInstaller.StopService("WinSrvSAW");  //Check if service is installed ServiceInstaller.ServiceIsInstalled("WinSrvSAW"); 
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + Environment.NewLine +
                    ex.InnerException;
            }
        }

        protected void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                //Removes the service 
                ServiceInstaller.Uninstall("WinSrvSAW");
                ServiceController svcController = new ServiceController("WinSrvSAW");
                if (svcController != null)
                {
                    lblServiceStatus.Text = svcController.Status.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        protected void btnTestMail_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient objSMTP = new SmtpClient("smtp.sawinfotech.com", 25);
                objSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSMTP.Timeout = 600000;
                objSMTP.Credentials = new System.Net.NetworkCredential("username", "password");
                MailMessage objMsg = new MailMessage("admin@sawinfotech.com", "sunit82@gmail.com", "test",
                    DateTime.Now.ToString() + Environment.NewLine + "s.a.w");
                objSMTP.Send(objMsg);
                lblMessage.Text = "Mail Sent";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + Environment.NewLine + ex.InnerException;
            }
        }
    }

    [Flags]
    public enum ServiceManagerRights
    {
        Connect = 0x0001,
        CreateService = 0x0002,
        EnumerateService = 0x0004,
        Lock = 0x0008,
        QueryLockStatus = 0x0010,
        ModifyBootConfig = 0x0020,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | Connect | CreateService |
        EnumerateService | Lock | QueryLockStatus | ModifyBootConfig)
    }

    [Flags]
    public enum ServiceRights
    {
        QueryConfig = 0x1,
        ChangeConfig = 0x2,
        QueryStatus = 0x4,
        EnumerateDependants = 0x8,
        Start = 0x10,
        Stop = 0x20,
        PauseContinue = 0x40,
        Interrogate = 0x80,
        UserDefinedControl = 0x100,
        Delete = 0x00010000,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | QueryConfig | ChangeConfig |
        QueryStatus | EnumerateDependants | Start | Stop | PauseContinue |
        Interrogate | UserDefinedControl)
    }

    public enum ServiceBootFlag
    {
        Start = 0x00000000,
        SystemStart = 0x00000001,
        AutoStart = 0x00000002,
        DemandStart = 0x00000003,
        Disabled = 0x00000004
    }

    public enum ServiceState
    {
        Unknown = -1, // The state cannot be (has not been) retrieved.
        NotFound = 0, // The service is not known on the host server.
        Stop = 1, // The service is NET stopped.
        Run = 2, // The service is NET started.
        Stopping = 3,
        Starting = 4,
    }

    public enum ServiceControl
    {
        Stop = 0x00000001,
        Pause = 0x00000002,
        Continue = 0x00000003,
        Interrogate = 0x00000004,
        Shutdown = 0x00000005,
        ParamChange = 0x00000006,
        NetBindAdd = 0x00000007,
        NetBindRemove = 0x00000008,
        NetBindEnable = 0x00000009,
        NetBindDisable = 0x0000000A
    }

    public enum ServiceError
    {
        Ignore = 0x00000000,
        Normal = 0x00000001,
        Severe = 0x00000002,
        Critical = 0x00000003
    }

    public class ServiceInstaller
    {
        private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        private const int SERVICE_WIN32_OWN_PROCESS = 0x00000010;

        [StructLayout(LayoutKind.Sequential)]
        private class SERVICE_STATUS
        {
            public int dwServiceType = 0;
            public ServiceState dwCurrentState = 0;
            public int dwControlsAccepted = 0;
            public int dwWin32ExitCode = 0;
            public int dwServiceSpecificExitCode = 0;
            public int dwCheckPoint = 0;
            public int dwWaitHint = 0;
        }

        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerA")]
        private static extern IntPtr OpenSCManager(string lpMachineName, string
        lpDatabaseName, ServiceManagerRights dwDesiredAccess);
        [DllImport("advapi32.dll", EntryPoint = "OpenServiceA",
        CharSet = CharSet.Ansi)]
        private static extern IntPtr OpenService(IntPtr hSCManager, string
        lpServiceName, ServiceRights dwDesiredAccess);
        [DllImport("advapi32.dll", EntryPoint = "CreateServiceA")]
        private static extern IntPtr CreateService(IntPtr hSCManager, string
        lpServiceName, string lpDisplayName, ServiceRights dwDesiredAccess, int
        dwServiceType, ServiceBootFlag dwStartType, ServiceError dwErrorControl,
        string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string
        lpDependencies, string lp, string lpPassword);
        [DllImport("advapi32.dll")]
        private static extern int CloseServiceHandle(IntPtr hSCObject);
        [DllImport("advapi32.dll")]
        private static extern int QueryServiceStatus(IntPtr hService,
        SERVICE_STATUS lpServiceStatus);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern int DeleteService(IntPtr hService);
        [DllImport("advapi32.dll")]
        private static extern int ControlService(IntPtr hService, ServiceControl
        dwControl, SERVICE_STATUS lpServiceStatus);
        [DllImport("advapi32.dll", EntryPoint = "StartServiceA")]
        private static extern int StartService(IntPtr hService, int
        dwNumServiceArgs, int lpServiceArgVectors);


        private ServiceInstaller()
        {
        }

        public static void Uninstall(string ServiceName)
        {
            IntPtr scman = OpenSCManager(null, null, ServiceManagerRights.Connect);
            try
            {
                IntPtr service = OpenService(scman, ServiceName,
                ServiceRights.StandardRightsRequired | ServiceRights.Stop |
                ServiceRights.QueryStatus);
                if (service == IntPtr.Zero)
                {
                    throw new ApplicationException("Service not installed.");
                }
                try
                {
                    //StopService(ServiceName);
                    ServiceController svcController = new ServiceController("WinSrvSAW");
                    if (svcController != null)
                    {
                        if (svcController.Status == ServiceControllerStatus.Running)
                        {
                            svcController.Stop();
                            svcController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                        }
                    }
                    int ret = DeleteService(service);
                    if (ret == 0)
                    {
                        int error = Marshal.GetLastWin32Error();
                        throw new ApplicationException("Could not delete service " + error);
                    }
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scman);
            }
        }

        public static bool ServiceIsInstalled(string ServiceName)
        {
            IntPtr scman = OpenSCManager(null, null, ServiceManagerRights.Connect);
            try
            {
                IntPtr service = OpenService(scman, ServiceName,
                ServiceRights.QueryStatus);
                if (service == IntPtr.Zero) return false;
                CloseServiceHandle(service);
                return true;
            }
            finally
            {
                CloseServiceHandle(scman);
            }
        }

        public static void InstallAndStart(string ServiceName, string DisplayName,
        string FileName)
        {
            IntPtr scman = OpenSCManager(null, null, ServiceManagerRights.Connect |
            ServiceManagerRights.CreateService);
            try
            {
                IntPtr service = OpenService(scman, ServiceName,
                ServiceRights.QueryStatus | ServiceRights.Start);
                if (service == IntPtr.Zero)
                {
                    service = CreateService(scman, ServiceName, DisplayName,
                    ServiceRights.QueryStatus | ServiceRights.Start, SERVICE_WIN32_OWN_PROCESS,
                    ServiceBootFlag.AutoStart, ServiceError.Normal, FileName, null, IntPtr.Zero,
                    null, null, null);
                }
                if (service == IntPtr.Zero)
                {
                    throw new ApplicationException("Failed to install service.");
                }
                try
                {
                    StartService(ServiceName);
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scman);
            }
        }

        public static void StartService(string Name)
        {
            IntPtr scman = OpenSCManager(null, null, ServiceManagerRights.Connect);
            try
            {
                //IntPtr hService = OpenService(scman, Name, ServiceRights.QueryStatus |
                //ServiceRights.Start);
                ServiceController svcController = new ServiceController("WinSrvSAW");
                if (svcController != null)
                {
                    
                    if (svcController.Status == ServiceControllerStatus.Running)
                    {
                        svcController.Stop();
                        svcController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                    svcController.Start();
                    
                }
            }
            finally
            {
                CloseServiceHandle(scman);
            }
        }

        public static void StopService(string Name)
        {
            IntPtr scman = OpenSCManager(null, null, ServiceManagerRights.Connect);
            try
            {
                IntPtr hService = OpenService(scman, Name, ServiceRights.QueryStatus |
                ServiceRights.Stop);
                if (hService == IntPtr.Zero)
                {
                    throw new ApplicationException("Could not open service.");
                }
                try
                {
                    StopService(Name);
                }
                finally
                {
                    CloseServiceHandle(hService);
                }
            }
            finally
            {
                CloseServiceHandle(scman);
            }
        }
    }
}
