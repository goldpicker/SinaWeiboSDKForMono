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
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
//using Windows.Security.Authentication.Web;
//using Windows.Storage;

namespace WeiboSDKForWinRT
{
	public interface IAppSetting{
	 	object this [string index] {
			get;
			set;
		}

		Boolean ContainsKey(String key);

	}

    public class ApplicationDataContainer
{
		public IAppSetting Values {
			get;
			set;
		}

}

}
