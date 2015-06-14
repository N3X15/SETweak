/**
* AUTOMATICALLY GENERATED
* 
* Copyright (c) 2015 Rob "N3X15" Nelson <nexisentertainment@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/
using System;
using System.Collections.Generic;
using RestSharp.Serializers;

namespace SETweaks.Steam.DataBindings
{
    public class PublishedFileDetailList
    {
        // u'publishedfiledetails': [{"ban_reason": "", "creator": "76561197978458617", "time_created": 1406920901, "hcontent_file": "46504330037938199", "result": 1, "file_size": 13985574, "title": "VINTAGE Fighter Cockpit", "views": 62242, "filename": "tmpa360.tmp", "tags": [{"tag": "mod"}, {"tag": "Block"}], "publishedfileid": "294534489", "consumer_app_id": 244850, "favorited": 1249, "description": "[b]Description:[/b] This is a vintage version of Fighter Cockpit, with old textures and buildstate models before it was injected into vanila game. I left it here because of legacy option, and for people who don't like new textures and reduced buildstates for some reason.\r\n\r\nThis is a LEGACY mod. That means it is here for purely historical accounts. I will not update model to accomodate to any future changes of the gameplay, as of it is already in Vanila and updated.\r\n\r\nCheck my [url=http://forums.keenswh.com/post/6697919]thread[/url]\r\n\r\n[b]Current Function:[/b] Functional\r\n\r\n[b]Planned Function:[/b] Cockpit\r\n\r\n[b]Available on:[/b] Small ships\r\n\r\n[b]Adapted for Survival:[/b] Yes\r\n\r\n[b]Polygons:[/b] 3000", "subscriptions": 54161, "banned": 0, "visibility": 0, "creator_app_id": 244850, "lifetime_favorited": 1461, "lifetime_subscriptions": 71652, "hcontent_preview": "46504330037939465", "time_updated": 1431204929, "file_url": "http://cloud-4.steamusercontent.com/ugc/46504330037938199/836224DD8DC9D3D4B79970CF215D8F77CE6A016A/", "preview_url": "http://images.akamai.steamusercontent.com/ugc/46504330037939465/EE4F95CD2C7D7941D53CB9FE0D73A1564BF335F2/"}]
        [SerializeAs(Name = "publishedfiledetails")]
        public List<PublishedFileDetails> PublishedFileDetails { get; set; }

        // u'resultcount': 1
        [SerializeAs(Name = "resultcount")]
        public int Resultcount { get; set; }

        // u'result': 1
        [SerializeAs(Name = "result")]
        public int Result { get; set; }

    }
}
