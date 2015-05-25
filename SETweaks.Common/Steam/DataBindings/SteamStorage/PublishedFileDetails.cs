using System.Collections.Generic;
using RestSharp.Serializers;

namespace SETweaks.Steam.DataBindings
{
    public class PublishedFileDetails
    {
        public class Tag
        {
            public string Value {get;set;}
        }
        // u'ban_reason': u''
        [SerializeAs(Name = "ban_reason")]
        public string BanReason { get; set; }

        // u'creator': "76561197978458617"
        [SerializeAs(Name = "creator")]
        public string Creator { get; set; }

        // u'time_created': 1406920901
        [SerializeAs(Name = "time_created")]
        public int TimeCreated { get; set; }

        // u'hcontent_file': "46504330037938199"
        [SerializeAs(Name = "hcontent_file")]
        public string HContentFile { get; set; }

        // u'result': 1
        [SerializeAs(Name = "result")]
        public int Result { get; set; }

        // u'file_size': 13985574
        [SerializeAs(Name = "file_size")]
        public int FileSize { get; set; }

        // u'title': "VINTAGE Fighter Cockpit"
        [SerializeAs(Name = "title")]
        public string Title { get; set; }

        // u'views': 62242
        [SerializeAs(Name = "views")]
        public int Views { get; set; }

        // u'filename': "tmpa360.tmp"
        [SerializeAs(Name = "filename")]
        public string Filename { get; set; }

        // u'tags': [{"tag": "mod"}, {"tag": "Block"}]
        [SerializeAs(Name = "tags")]
        public List<Tag> Tags { get; set; }

        // u'publishedfileid': "294534489"
        [SerializeAs(Name = "publishedfileid")]
        public string PublishedFileID { get; set; }

        // u'consumer_app_id': 244850
        [SerializeAs(Name = "consumer_app_id")]
        public int ConsumerAppID { get; set; }

        // u'favorited': 1249
        [SerializeAs(Name = "favorited")]
        public int Favorited { get; set; }

        // u'description': "[b]Description:[/b] This is a vintage version of Fighter Cockpit, with old textures and buildstate models before it was injected into vanila game. I left it here because of legacy option, and for people who don't like new textures and reduced buildstates for some reason.\r\n\r\nThis is a LEGACY mod. That means it is here for purely historical accounts. I will not update model to accomodate to any future changes of the gameplay, as of it is already in Vanila and updated.\r\n\r\nCheck my [url=http://forums.keenswh.com/post/6697919]thread[/url]\r\n\r\n[b]Current Function:[/b] Functional\r\n\r\n[b]Planned Function:[/b] Cockpit\r\n\r\n[b]Available on:[/b] Small ships\r\n\r\n[b]Adapted for Survival:[/b] Yes\r\n\r\n[b]Polygons:[/b] 3000"
        [SerializeAs(Name = "description")]
        public string Description { get; set; }

        // u'subscriptions': 54161
        [SerializeAs(Name = "subscriptions")]
        public int Subscriptions { get; set; }

        // u'banned': 0
        [SerializeAs(Name = "banned")]
        public int Banned { get; set; }

        // u'visibility': 0
        [SerializeAs(Name = "visibility")]
        public int Visibility { get; set; }

        // u'creator_app_id': 244850
        [SerializeAs(Name = "creator_app_id")]
        public int CreatorAppID { get; set; }

        // u'lifetime_favorited': 1461
        [SerializeAs(Name = "lifetime_favorited")]
        public int LifetimeFavorited { get; set; }

        // u'lifetime_subscriptions': 71652
        [SerializeAs(Name = "lifetime_subscriptions")]
        public int LifetimeSubscriptions { get; set; }

        // u'hcontent_preview': "46504330037939465"
        [SerializeAs(Name = "hcontent_preview")]
        public string HContentPreview { get; set; }

        // u'time_updated': 1431204929
        [SerializeAs(Name = "time_updated")]
        public int TimeUpdated { get; set; }

        // u'file_url': "http://cloud-4.steamusercontent.com/ugc/46504330037938199/836224DD8DC9D3D4B79970CF215D8F77CE6A016A/"
        [SerializeAs(Name = "file_url")]
        public string FileURL { get; set; }

        // u'preview_url': "http://images.akamai.steamusercontent.com/ugc/46504330037939465/EE4F95CD2C7D7941D53CB9FE0D73A1564BF335F2/"
        [SerializeAs(Name = "preview_url")]
        public string PreviewURL { get; set; }

    }
}
