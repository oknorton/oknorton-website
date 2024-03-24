export interface Project {
  id: number;
  title: string;
  description: string;
  imageURL: string;
  date: Date;
  projectTags: ProjectTag[];
}

export interface ProjectTag {
  projectId: number;
  tagId: number;
  tag: Tag;
}

export interface Tag {
  id: number;
  name: string;
}
