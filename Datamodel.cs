using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace githubAPI
{
    public class APIErrorExcption : Exception
    {
        public System.Net.HttpStatusCode code { get; set; }
        public Result result { get; set; }
        public APIErrorExcption(System.Net.HttpStatusCode code, Result res) : base(res.ToString())
        {
            this.code = code;
            this.result = res;
            
        }
        
    }
    public class Result
    {
        public override string ToString()
        {
            return message;
        }
        [JsonProperty]
        public string message{get; set;}
        [JsonProperty]
        public string documentation_url{get; set;}

    }
    public class TokenResult : Result
    {
        [JsonProperty]
        public string access_token { get; set; }
         [JsonProperty]
       public string token_type { get; set; }
         [JsonProperty]
       public string scope { get; set; }
    }

    public class Repo
{
     [JsonProperty]
        public string id{get; set;}
     [JsonProperty]
        public string node_id{get; set;}
     [JsonProperty]
        public string name{get; set;}
     [JsonProperty]
        public string full_name{get; set;}
         
        [JsonProperty]
        public Owner owner{get; set;}
    
    public class Owner {
         [JsonProperty]
        public string login{get; set;}
        [JsonProperty]
        public string id{get; set;}
        [JsonProperty]
        public string node_id{get; set;}
        [JsonProperty]
        public string avatar_url{get; set;}
        [JsonProperty]
        public string gravatar_id{get; set;}
        [JsonProperty]
        public string url{get; set;}
        [JsonProperty]
        public string html_url{get; set;}
        [JsonProperty]
        public string followers_url{get; set;}
        [JsonProperty]
        public string following_url{get; set;}
        [JsonProperty]
        public string gists_url{get; set;}
        [JsonProperty]
        public string starred_url{get; set;}
        [JsonProperty]
        public string subscriptions_url{get; set;}
        [JsonProperty]
        public string organizations_url{get; set;}
        [JsonProperty]
        public string repos_url{get; set;}
        [JsonProperty]
        public string events_url{get; set;}
        [JsonProperty]
        public string received_events_url{get; set;}
        [JsonProperty]
        public string type{get; set;}
        [JsonProperty]
        public bool site_admin{get; set;}
    }
     [JsonProperty("private")]
        public bool IsPrivate{get; set;}
    [JsonProperty]
        public string html_url{get; set;}
    [JsonProperty]
        public string description{get; set;}
    [JsonProperty]
        public bool fork{get; set;}
    [JsonProperty]
        public string url{get; set;}
    [JsonProperty]
        public string forks_url{get; set;}
    [JsonProperty]
        public string keys_url{get; set;}
    [JsonProperty]
        public string collaborators_url{get; set;}
    [JsonProperty]
        public string teams_url{get; set;}
    [JsonProperty]
        public string hooks_url{get; set;}
    [JsonProperty]
        public string issue_events_url{get; set;}
    [JsonProperty]
        public string events_url{get; set;}
    [JsonProperty]
        public string assignees_url{get; set;}
    [JsonProperty]
        public string branches_url{get; set;}
    [JsonProperty]
        public string tags_url{get; set;}
    [JsonProperty]
        public string blobs_url{get; set;}
    [JsonProperty]
        public string git_tags_url{get; set;}
    [JsonProperty]
        public string git_refs_url{get; set;}
    [JsonProperty]
        public string trees_url{get; set;}
    [JsonProperty]
        public string statuses_url{get; set;}
    [JsonProperty]
        public string languages_url{get; set;}
    [JsonProperty]
        public string stargazers_url{get; set;}
    [JsonProperty]
        public string contributors_url{get; set;}
    [JsonProperty]
        public string subscribers_url{get; set;}
    [JsonProperty]
        public string subscription_url{get; set;}
    [JsonProperty]
        public string commits_url{get; set;}
    [JsonProperty]
        public string git_commits_url{get; set;}
    [JsonProperty]
        public string comments_url{get; set;}
    [JsonProperty]
        public string issue_comment_url{get; set;}
    [JsonProperty]
        public string contents_url{get; set;}
    [JsonProperty]
        public string compare_url{get; set;}
    [JsonProperty]
        public string merges_url{get; set;}
    [JsonProperty]
        public string archive_url{get; set;}
    [JsonProperty]
        public string downloads_url{get; set;}
    [JsonProperty]
        public string issues_url{get; set;}
    [JsonProperty]
        public string pulls_url{get; set;}
    [JsonProperty]
        public string milestones_url{get; set;}
    [JsonProperty]
        public string notifications_url{get; set;}
    [JsonProperty]
        public string labels_url{get; set;}
    [JsonProperty]
        public string releases_url{get; set;}
     [JsonProperty]
        public string deployments_url{get; set;}
     [JsonProperty]
        public DateTime created_at{get; set;}
     [JsonProperty]
        public DateTime updated_at{get; set;}
     [JsonProperty]
        public DateTime pushed_at{get; set;}
     [JsonProperty]
        public string git_url{get; set;}
     [JsonProperty]
        public string ssh_url{get; set;}
     [JsonProperty]
        public string clone_url{get; set;}
     [JsonProperty]
        public string svn_url{get; set;}
     [JsonProperty]
        public string homepage{get; set;}
     [JsonProperty]
        public int size{get; set;}
     [JsonProperty]
        public int stargazers_count{get; set;}
     [JsonProperty]
        public int watchers_count{get; set;}
     [JsonProperty]
        public string language{get; set;}
     [JsonProperty]
        public bool has_issues{get; set;}
     [JsonProperty]
        public bool has_projects{get; set;}
     [JsonProperty]
        public bool has_downloads{get; set;}
     [JsonProperty]
        public bool has_wiki{get; set;}
     [JsonProperty]
        public bool has_pages{get; set;}
     [JsonProperty]
        public int forks_count{get; set;}
     [JsonProperty]
        public string mirror_url{get; set;}
     [JsonProperty]
        public bool archived{get; set;}
     [JsonProperty]
        public int open_issues_count{get; set;}
     [JsonProperty]
        public string license{get; set;}
     [JsonProperty]
        public int forks{get; set;}
     [JsonProperty]
        public int open_issues{get; set;}
     [JsonProperty]
        public int watchers{get; set;}
     [JsonProperty]
        public string default_branch{get; set;}
        [JsonProperty]
     public Permissions permissions{get; set;}
public class Permissions{
     [JsonProperty]
        public bool admin{get; set;}
      [JsonProperty]
        public bool push{get; set;}
     [JsonProperty]
        public bool pull{get; set;}
     [JsonProperty]
        public bool allow_squash_merge{get; set;}
     [JsonProperty]
        public bool allow_merge_commit{get; set;}
     [JsonProperty]
        public bool allow_rebase_merge{get; set;}
}
     [JsonProperty]
        public int network_count{get; set;}
     [JsonProperty]
        public int subscribers_count{get; set;}
}
    /*
    public class Repo
    {
        [JsonProperty]
     public string  id{ get; set; }
          [JsonProperty]
    public string  node_id{ get; set; }
          [JsonProperty]
    public string name{ get; set; }
          [JsonProperty]
    public string  full_name{ get; set; }

          [JsonProperty]
        public Owner owner{get; set;}
    public class Owner {
    
          [JsonProperty]
        public string login{get; set;}
          [JsonProperty]
        public string id{get; set;}
        [JsonProperty]
      public string  type{get; set;}
          [JsonProperty]
      public string site_admin{get; set;}
    }
        [JsonProperty("private")]
    public bool is_private{get; set;}
          [JsonProperty]
    public string html_url{get; set;}
          [JsonProperty]
    public string  description{get; set;}

          [JsonProperty]
    public bool fork {get; set;}
          [JsonProperty]
    public string url {get; set;}
          [JsonProperty]
    public string archive_url {get; set;}
          [JsonProperty]
    public string assignees_url {get; set;}
         [JsonProperty]
    public string blobs_url {get; set;}
       [JsonProperty]
    public string branches_url {get; set;}
         [JsonProperty]
    public string collaborators_url {get; set;}
       [JsonProperty]
      public string   comments_url {get; set;}
          [JsonProperty]
    public string commits_url {get; set;}
          [JsonProperty]
        public string compare_url {get; set;}
        [JsonProperty]
        public string contents_url {get; set;}
          [JsonProperty]
       public string  contributors_url {get; set;}
          [JsonProperty]
  public string   deployments_url {get; set;}
          [JsonProperty]
   public string  downloads_url {get; set;}
      [JsonProperty]
   public string  events_url {get; set;}
      [JsonProperty]
   public string  forks_url {get; set;}
          [JsonProperty]
   public string  git_commits_url {get; set;}
       [JsonProperty]
   public string  git_refs_url {get; set;}
          [JsonProperty]
   public string  git_tags_url {get; set;}
         [JsonProperty]
   public string  git_url {get; set;}
          [JsonProperty]
   public string  issue_comment_url {get; set;}
          [JsonProperty]
   public string  issue_events_url {get; set;}
          [JsonProperty]
   public string  issues_url {get; set;}
          [JsonProperty]
   public string  keys_url {get; set;}
          [JsonProperty]
   public string  labels_url {get; set;}
          [JsonProperty]
   public string  languages_url {get; set;}
          [JsonProperty]
   public string  merges_url {get; set;}
          [JsonProperty]
   public string  milestones_url {get; set;}
          [JsonProperty]
   public string  notifications_url {get; set;}
          [JsonProperty]
   public string  pulls_url {get; set;}
          [JsonProperty]
    public string  releases_url {get; set;}
          [JsonProperty]
    public string  ssh_url{get; set;}
       [JsonProperty]
    public string  stargazers_url {get; set;}
          [JsonProperty]
   public string  statuses_url {get; set;}
          [JsonProperty]
   public string  subscribers_url {get; set;}
          [JsonProperty]
   public string  subscription_url {get; set;}
          [JsonProperty]
    public string tags_url {get; set;}
          [JsonProperty]
    public string teams_url {get; set;}
          [JsonProperty]
   public string  trees_url {get; set;}
          [JsonProperty]
   public string  clone_url {get; set;}
          [JsonProperty]
   public string  mirror_url {get; set;}
          [JsonProperty]
    public string hooks_url {get; set;}
          [JsonProperty]
   public string  svn_url {get; set;}
          [JsonProperty]
          public string homepage { get; set; }
          [JsonProperty]
    public string language {get; set;}
      [JsonProperty]
    public int forks_count {get; set;}
      [JsonProperty]
    public int  stargazers_count {get; set;}
      [JsonProperty]
    public int  watchers_count {get; set;}
      [JsonProperty]
    public int size {get; set;}
      [JsonProperty]
    public string default_branch {get; set;}
      [JsonProperty]
     public string open_issues_count {get; set;}
      [JsonProperty]
   public string[] topics {get; set;}
      [JsonProperty]
    public bool has_issues {get; set;}
      [JsonProperty]
    public bool has_projects {get; set;}
      [JsonProperty]
    public bool has_wiki {get; set;}
      [JsonProperty]
    public bool has_pages {get; set;}
      [JsonProperty]
    public bool has_downloads {get; set;}
      [JsonProperty]
    public bool archived {get; set;}
      [JsonProperty]
    public DateTime pushed_at {get; set;}
      [JsonProperty]
    public DateTime created_at {get; set;}
      [JsonProperty]
    public DateTime updated_at {get; set;}
   
    }
    */
    public class UserResult : Result
    { 
         [JsonProperty]
         public string login{get; set;}
        [JsonProperty]
         public string id { get; set; }
        /*"node_id":"MDQ6VXNlcjQyNDYxMzI2","avatar_url":"https://avatars2.githubusercontent.com/u/42461326?v=4","gravatar_id":"","url":"https://api.github.com/users/edomurasaki2000","html_url":"https://github.com/edomurasaki2000","followers_url":"https://api.github.com/users/edomurasaki2000/followers","following_url":"https://api.github.com/users/edomurasaki2000/following{/other_user}","gists_url":"https://api.github.com/users/edomurasaki2000/gists{/gist_id}","starred_url":"https://api.github.com/users/edomurasaki2000/starred{/owner}{/repo}","subscriptions_url":"https://api.github.com/users/edomurasaki2000/subscriptions","organizations_url":"https://api.github.com/users/edomurasaki2000/orgs","repos_url":"https://api.github.com/users/edomurasaki2000/repos","events_url":"https://api.github.com/users/edomurasaki2000/events{/privacy}","received_events_url":"https://api.github.com/users/edomurasaki2000/received_events","type":"User","site_admin":false,"name":null,"company":null,"blog":"","location":null,"email":null,"hireable":null,"bio":null,"public_repos":1,"public_gists":0,"followers":0,"following":0,"created_at":"2018-08-17T06:07:51Z","updated_at":"2018-08-17T07:21:22Z","private_gists":0,"total_private_repos":0,"owned_private_repos":0,"disk_usage":931,"collaborators":0,"two_factor_authentication":false,"plan":{"name":"free","space":976562499,"collaborators":0,"private_repos":0}
    */
    }
}
