
export interface GitHubUser {
  login: string;
  id: number;
  avatar_url: string;
  html_url: string;
  name: string;
  company: string;
  blog: string;
  location: string;
  email: string;
  bio: string;
  twitter_username: string;
  followers: number;
  following: number;
  public_repos: number;
  public_gists: number;
  created_at: Date;
  updated_at: Date;
  repos_url: string;
  followers_url: string;
  following_url: string;
  starred_url: string;
  subscriptions_url: string;
  organizations_url: string;
  events_url: string;
  received_events_url: string;
  site_admin: boolean;
  hireable: boolean | null;
  total_private_repos: number;
  owned_private_repos: number;
  disk_usage: number;
  collaborators: number;
  plan: GitHubPlan;
}

export interface GitHubPlan {
  name: string;
  space: number;
  private_repos: number;
  collaborators: number;
}
