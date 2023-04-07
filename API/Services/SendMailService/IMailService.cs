﻿using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.SendMailService
{
    public interface IMailService
    {
            Task SendEmailAsync(MailRequest mailRequest);

    }
}
