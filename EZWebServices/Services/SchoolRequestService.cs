﻿using EZWebServices.Helpers;
using EZWebServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EZWebServices.Services
{
    public class SchoolRequestService
    {
        public bool CreateSchoolAccount(SchoolReuqest request)
        {
            try
            {
                var con = new SqlConnection(ConnectionHelper.LGAConnection());
                using (SqlCommand cmd = new SqlCommand("INSERT INTO SchoolAccount(Lastname,Middlename,Firstname,Birthday,Address,Email,MobileNumber,SchoolNumber,Password,Gender,IsAdmin,IsFaculty, TeacherProfile) VALUES(@Lastname,@Middlename,@Firstname, @Birthday, @Address, @Email,@SchoolNumber,@Password, @MobileNumber,@Gender,@IsAdmin, @IsFaculty, @TeacherProfile); SELECT SCOPE_IDENTITY()", con))
                {
                    cmd.Parameters.AddWithValue("@Lastname", request.LastName);
                    cmd.Parameters.AddWithValue("@Middlename", request.Middlename);
                    cmd.Parameters.AddWithValue("@Firstname", request.Firstname);
                    cmd.Parameters.AddWithValue("@Birthday", request.Birthday);
                    cmd.Parameters.AddWithValue("@Address", request.Address);
                    cmd.Parameters.AddWithValue("@Email", request.Email);
                    cmd.Parameters.AddWithValue("@SchoolNumber", request.SchoolNumber);
                    cmd.Parameters.AddWithValue("@Password", request.Password);                    
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@Gender", request.Gender);
                    cmd.Parameters.AddWithValue("@IsAdmin", request.IsAdmin);
                    cmd.Parameters.AddWithValue("@IsFaculty", request.IsFaculty);
                    cmd.Parameters.AddWithValue("@TeacherProfile", request.TeacherProfile);
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                    return true;
                }
                
            }
            catch(Exception e)
            {
                return false;                             
            }
        }

        public bool DeleteSchoolAccount(int ID)
        {
            try
            {
                var con = new SqlConnection(ConnectionHelper.LGAConnection());
                using (SqlCommand cmd = new SqlCommand("DELETE FROM SchoolAccount WHERE ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateSchoolAccount(SchoolReuqest request)
        {
            try
            {
                var con = new SqlConnection(ConnectionHelper.LGAConnection());
                using (SqlCommand cmd = new SqlCommand("UPDATE SchoolAccount SET Lastname = @Lastname, Middlename = @Middlename, Firstname = @Firstname, SchoolNumber = @SchoolNumber, Password = @Password, MobileNumber = @MobileNumber, Gender = @Gender, IsAdmin = @IsAdmin, Birthday = @Birthday, Address = @Address, Email = @Email WHERE ID = @ID", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", request.id);
                    cmd.Parameters.AddWithValue("@Lastname", request.LastName);
                    cmd.Parameters.AddWithValue("@Middlename", request.Middlename);
                    cmd.Parameters.AddWithValue("@Firstname", request.Firstname);
                    cmd.Parameters.AddWithValue("@SchoolNumber", request.SchoolNumber);
                    cmd.Parameters.AddWithValue("@Password", request.Password);
                    //cmd.Parameters.AddWithValue("@TeacherProfile", request.TeacherProfile);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@Gender", request.Gender);
                    cmd.Parameters.AddWithValue("@Birthday", request.Birthday);
                    cmd.Parameters.AddWithValue("@Address", request.Address);
                    cmd.Parameters.AddWithValue("@Email", request.Email);
                    cmd.Parameters.AddWithValue("@IsAdmin", request.IsAdmin);                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;             
            }
        }

        public bool UpdateSchoolAccountPassword(SchoolReuqest request)
        {
            try
            {
                var con = new SqlConnection(ConnectionHelper.LGAConnection());
                using (SqlCommand cmd = new SqlCommand("UPDATE SchoolAccount SET Password = @Password WHERE ID = @ID", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", request.id);                   
                    cmd.Parameters.AddWithValue("@Password", request.Password);                                
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;             
            }
        }
    }
}