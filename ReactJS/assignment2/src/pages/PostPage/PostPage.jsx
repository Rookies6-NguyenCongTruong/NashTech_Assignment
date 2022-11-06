import { useState } from "react";
import { useEffect } from "react"

const PostPage = () => {
    const [posts, setPosts] = useState([]);
    useEffect(() => {
        const response = axios.get("/getPost");

        response
            .then(response => {
                setPosts(response);
            })
            .catch((error) => { });
    }, []);

    return <div> Post List </div>
};

export default PostPage;