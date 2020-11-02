import axios from 'axios';

export default axios.create({
    baseURL: 'http://localhost:44301/api/BlogPosts',
    headers: {
        "Content-type": "application/json"
    }
});
