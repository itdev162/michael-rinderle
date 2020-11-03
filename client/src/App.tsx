import './app.css';

import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';

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

  viewPost = (post) => {
    console.log(`view ${post.title}`);
    this.setState({ post: post });
  }

  
  render() {
    const { posts, post } = this.state;

    return (
      <Router>
        <div className="App">
          <header className="App-Header">
            BlogBox
          </header>
          <main className="App-Content">
            <switch>
              <Route exact path="/">
                <PostList posts={posts} clickPost={this.viewPost}/>
              </Route>
              <Route path="/posts/:postId">
                <Post post={post}/>
              </Route>
            </switch>
          </main>
        </div>
      </Router>     
    );
  }
}

export default App;
