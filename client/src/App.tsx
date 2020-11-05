import './App.css';

import { Link, Route, BrowserRouter as Router, Switch } from 'react-router-dom';

import CreatePost from './components/Post/CreatePost';
import EditPost from './components/Post/EditPost';
import Post from './components/Post/Post';
import PostList from './components/PostList/PostList';
import React from 'react';
import axios from 'axios';

class App extends React.Component {
  
  state = {
    posts: [],
    post: null
  }
  
  componentDidMount(){
    axios.get('http://localhost:5000/api/posts')
      .then((response) =>{
        this.setState({
          posts : response.data
        })
      })
      .catch((error) =>{
        console.error("Error fetching data: ${error}");
      })
  }

  deletePost = post => {
    axios
      .delete(`http://localhost:5000/api/posts/${post.id}`)
      .then(response => {
        const newPosts = this.state.posts.filter(p => p.id !== post.id);
        this.setState({
          posts: [...newPosts]
        });
      })
      .catch(error => {
        console.error(`Error deleting post: ${error}`);
      })
  };

  viewPost = (post) => {
    console.log(`view ${post.title}`);
    this.setState({ post: post });
  }

  editPost = post => {
    this.setState({
      post: post
    });
  }
  
  onPostCreated = post => {
    const newPosts = [...this.state.posts, post];

    this.setState({
      posts: newPosts
    });
  }

  onPostUpdated = post => {
    console.log('updated post: ', post);
    const newPosts = [...this.state.posts];
    const index = newPosts.findIndex(p => p.id === post.id);
    newPosts[index] = post;
    this.setState({
      posts: newPosts
    });
  }

  render() {
    const { posts, post } = this.state;

    return (
      <Router>
        <div className="App">
          <header className="App-header">BlogBox</header>
          <nav>
            <Link to="/">Home</Link>
            <Link to="/new-post">New Post</Link>
          </nav>
          <main className="App-Content">
            <switch>
              <Route exact path="/">
                <PostList
                  posts={posts}
                  clickPost={this.viewPost}
                  deletePost={this.deletePost}/>
              </Route>
              <Route path="/posts/:postId">
                <Post post={post}/>
              </Route>
              <Route path="/new-post">
                <CreatePost onPostCreated={this.onPostCreated}/>
              </Route>
              <Route path="/edit-post/:postId">
                <EditPost post={post} onPostCreated={this.onPostCreated}/>
              </Route>
            </switch>
          </main>
        </div>
      </Router>     
    );
  }
}

export default App;
