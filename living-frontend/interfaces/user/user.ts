import { Group, Like, Post } from "../posts/post";

export interface User {
    id: number;
    username: string;
    name: string;
    email: string;
    photo_url: string;
    banner_url: string;
    bio: string;
    created_at: string;
    updated_at: string;
    birth_date: string;
    posts: Array<Post>;
    followers: Array<User>;
    following: Array<User>;
    likes: Array<Like>;
    groups: Array<Group>;
}

export interface UserRequest {
    username: string;
    name: string;
    email: string;
    password: string;
    password_confirmation: string;
    birth_date: string;
    bio: string;
    photo: File;
    banner: File;
}