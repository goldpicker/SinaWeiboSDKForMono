/*
 * Author: hljie.
 * 
 * Description: 新浪微博OAuth2.0授权。
 *  
 *  采用官方授权页方式，包括了授权Token的过期验证。
 * 
 * Date: 2013.1.30
 * 
 * 
 * ===============================================================================
 * Copyright (c) Sina. 
 * All rights reserved.
 * ===============================================================================
 */
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
//using Windows.Security.Authentication.Web;
//using Windows.Storage;

namespace WeiboSDKForWinRT
{
   public class ApplicationData
{
		private static ApplicationData instance = new ApplicationData(); 

		public static ApplicationData Current{
			get{
				return instance;
			}
		}

		private ApplicationData(){
			this.LocalSettings = new ApplicationDataContainer();
		}

		public ApplicationDataContainer LocalSettings {
			get;
			set;
		}
}

}
