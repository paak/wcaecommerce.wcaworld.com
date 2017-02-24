using System;
using System.Web.SessionState;

namespace ecom
{
    /// <summary>
    /// Encapsulates the session state
    /// </summary>
    public sealed class LoginInfo
    {
        private HttpSessionState _session;
        public LoginInfo(HttpSessionState session)
        {
            this._session = session;
        }

        public string Username
        {
            get { return (this._session["Username"] ?? string.Empty).ToString(); }
            set { this._session["Username"] = value; }
        }

        public string FullName
        {
            get { return (this._session["FullName"] ?? string.Empty).ToString(); }
            set { this._session["FullName"] = value; }
        }
        public int Cid
        {
            get { return Convert.ToInt32((this._session["Cid"] ?? -1)); }
            set { this._session["Cid"] = value; }
        }
    }
}