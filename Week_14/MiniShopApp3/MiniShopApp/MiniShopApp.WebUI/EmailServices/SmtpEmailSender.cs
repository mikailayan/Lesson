﻿using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.EmailServices
{
    public class SmtpEmailSender : IEmailSender
    {
        //aspsettings içerisindeki bilgileri alalım(Dependecy Injection)
        private string _host;
        private int _port;
        private bool _enableSSl;
        private string _userName;
        private string _password;
        public SmtpEmailSender(string host, int port, bool enableSSl, string userName, string password)
        {
            _host = host;
            _port = port;
            _enableSSl = enableSSl;
            _userName = userName;
            _password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(this._host, this._port)
            {
                Credentials = new NetworkCredential(this._userName,this._password),
                EnableSsl = this._enableSSl
            };
            return client.SendMailAsync(
                new MailMessage(this._userName, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                });
        }
    }
}
