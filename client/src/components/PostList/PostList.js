import PostListItem from './PostListItem';
import React from 'react';

const PostList = props => {
    const { posts, clickPost } = props;
    return posts.map(post => <PostListItem key={post.id} post={post} clickPost={clickPost} />);
}

export default PostList;