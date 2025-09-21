// 代码生成时间: 2025-09-21 08:58:21
// <copyright file="MessageNotificationSystem.cs" company="YourCompany">
// Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;

namespace YourCompany.MessageNotificationSystem
{
    /// <summary>
    /// 消息通知系统，用于发送不同类型的消息。
    /// </summary>
    public class MessageNotificationSystem
    {
        /// <summary>
        /// 发送文本消息。
        /// </summary>
        /// <param name="message">要发送的消息内容。</param>
        /// <param name="recipient">接收消息的对象。</param>
        public void SendTextMessage(string message, string recipient)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("消息内容不能为空。", nameof(message));
            }

            if (string.IsNullOrEmpty(recipient))
            {
                throw new ArgumentException("接收者不能为空。", nameof(recipient));
            }

            // 这里模拟消息发送过程，实际使用时可以替换为具体的API调用或消息队列
            Console.WriteLine($"发送消息：{message} 给 {recipient}。");
        }

        /// <summary>
        /// 发送电子邮件消息。
        /// </summary>
        /// <param name="subject">邮件主题。</param>
        /// <param name="body">邮件正文。</param>
        /// <param name="recipientEmail">接收者的电子邮件地址。</param>
        public void SendEmail(string subject, string body, string recipientEmail)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("邮件主题不能为空。", nameof(subject));
            }

            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentException("邮件正文不能为空。", nameof(body));
            }

            if (string.IsNullOrEmpty(recipientEmail))
            {
                throw new ArgumentException("接收者的电子邮件地址不能为空。", nameof(recipientEmail));
            }

            // 这里模拟邮件发送过程，实际使用时可以替换为具体的邮件发送API或服务
            Console.WriteLine($"发送邮件：主题 {subject}，正文 {body} 给 {recipientEmail}。");
        }

        // 可以根据需要添加更多类型的消息发送方法，比如推送通知、短信等。
    }
}
