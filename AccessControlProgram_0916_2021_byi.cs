// 代码生成时间: 2025-09-16 20:21:53
using System;
using System.Collections.Generic;

namespace AccessControl
{
    public class AccessControlProgram
    {
        private enum Permission
        {
            Read,
            Write,
            Execute
        }

        private enum Role
        {
            Admin,
            User,
            Guest
        }

        /// <summary>
        /// 检查用户是否拥有特定权限
        /// </summary>
        /// <param name="userRole">用户角色</param>
        /// <param name="requiredPermission">所需权限</param>
        /// <returns>是否可以访问</returns>
        public bool CheckAccess(Role userRole, Permission requiredPermission)
        {
            try
            {
                switch (userRole)
                {
                    case Role.Admin:
                        return true; // 管理员拥有所有权限
                    case Role.User:
                        switch (requiredPermission)
                        {
                            case Permission.Read:
                            case Permission.Write:
                                return true; // 用户可以读和写
                            default:
                                return false; // 用户不能执行
                        }
                    case Role.Guest:
                        switch (requiredPermission)
                        {
                            case Permission.Read:
                                return true; // 访客可以读
                            default:
                                return false; // 访客不能写或执行
                        }
                    default:
                        throw new ArgumentException("Unknown role"); // 未知角色
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking access: " + ex.Message);
                return false; // 发生异常时拒绝访问
            }
        }

        /// <summary>
        /// 主程序入口
        /// </summary>
        public static void Main(string[] args)
        {
            var program = new AccessControlProgram();
            var access = program.CheckAccess(Role.User, Permission.Read);
            Console.WriteLine("User has read access: " + access.ToString());

            access = program.CheckAccess(Role.Admin, Permission.Execute);
            Console.WriteLine("Admin has execute access: " + access.ToString());

            access = program.CheckAccess(Role.Guest, Permission.Write);
            Console.WriteLine("Guest has write access: " + access.ToString());
        }
    }
}