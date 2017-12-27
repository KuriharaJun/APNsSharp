//
// NotificationPayload.cs
//
// Author:
//       kurihara Jun <03s090@live.jp>
//
// Copyright (c) 2017 Kuruhara Jun
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.Collections.Generic;
using System.Linq;

namespace APNsSharp.Payloads
{
    public class NotificationPayload
    {
        /// <summary>
        /// The sound default.
        /// </summary>
        public const string SoundDefault = "default";

        /// <summary>
        /// Alertに設定可能なkey
        /// </summary>
        private static readonly string[] AlertKey = new string[] {
            "title",
            "body",
            "title-loc-key",
            "title-loc-args",
            "action-loc-key",
            "loc-key",
            "loc-args",
            "launch-image"
        };

        /// <summary>
        /// Gets or sets alert key.
        /// </summary>
        /// <value>The alert.</value>
        public IDictionary<string, object> Alert
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the badge key.
        /// </summary>
        /// <value>The badge.</value>
        public int Badge
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sound key.
        /// </summary>
        /// <value>The sound.</value>
        public string Sound
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content-avaiable key.
        /// </summary>
        /// <value>The content avaiable.</value>
        public string ContentAvaiable
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets category key.
        /// </summary>
        /// <value>The category.</value>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets thread-id key.
        /// </summary>
        /// <value>The thread identifier.</value>
        public string ThreadId
        {
            get;
            set;
        }

        /// <summary>
        /// Hases the error.
        /// </summary>
        /// <returns><c>true</c>, if error was hased, <c>false</c> otherwise.</returns>
        public bool HasError()
        {
            var alertError = Alert?.Keys.GroupJoin(AlertKey, _ => _, _ => _, (arg1, arg2) => new
            {
                SettingKey = arg1,
                Key = arg2
            }).SelectMany(x => x.Key.DefaultIfEmpty(), (x, y) => y).Any(string.IsNullOrEmpty);

            return alertError ?? false;
        }
    }
}
