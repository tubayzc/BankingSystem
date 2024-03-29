﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail;

public class MailHelper : IMailHelper
{


	private readonly SmtpClient _smtpClient;

	public MailHelper(IConfiguration configuration)
	{


		_smtpClient = new SmtpClient();
	}

	public async Task SendMailAsync(string subject, string body, string recepients)
	{
		if (_smtpClient.IsConnected)
		{
			await _smtpClient.DisconnectAsync(true);
		}

		await _smtpClient.ConnectAsync("smtp.gmail.com", 587, false);

		_smtpClient.Authenticate("nur97tuba@gmail.com", "Hello World");

		var email = new MimeMessage();

		email.From.Add(MailboxAddress.Parse("nur97tuba@gmail.com"));
		email.To.AddRange(InternetAddressList.Parse(recepients));

		email.Subject = subject;
		email.Body = new TextPart(TextFormat.Plain) { Text = body };

		await _smtpClient.SendAsync(email);

		if (_smtpClient.IsConnected)
		{
			await _smtpClient.DisconnectAsync(true);
		}
	}








}

