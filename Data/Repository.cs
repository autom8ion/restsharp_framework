namespace RESTSharpFW.Data
{
    public class Repository
    {
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public bool _private { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_wiki { get; set; }
        public bool is_template { get; set; }
        public int team_id { get; set; }
        public bool auto_init { get; set; }
        public string gitignore_template { get; set; }
        public string license_template { get; set; }
        public bool allow_squash_merge { get; set; }
        public bool allow_merge_commit { get; set; }
        public bool allow_rebase_merge { get; set; }

    }
}
