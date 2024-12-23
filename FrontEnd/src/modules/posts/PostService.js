export default {

    getPost(id) {
        return fetch(`https://localhost:7119/post/${id}`, { method: "GET" })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    createPost(data) {
        const formData = new FormData();
        formData.append('date', data.date.toISOString());
        formData.append('content', data.content);
        formData.append('image', data.image);

        return fetch("https://localhost:7119/post", {
            method: "POST",
            headers: {
                'Accept': 'application/json', // Keep this for the response type
                Authorization: `Bearer ${localStorage.getItem('user')}`, // Authentication header
            },
            body: formData, // FormData automatically sets multipart/form-data
        })
            .then(response => {
                if (response.status === 401) {
                    throw new Error("Unauthorized: Please check your login credentials or token.");
                } else if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    fetchPosts(page) {
        let link = page ? `https://localhost:7119/post?page=${page}` : "https://localhost:7119/post";
        return fetch(link, {
            method: "GET"
        })
            .then(response => {
                if (response.status === 401) {
                    throw new Error("Unauthorized: Please check your login credentials or token.");
                } else if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    deletePost(id) {
        return fetch(`https://localhost:7119/post/${id}`, {
            method: "DELETE",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('user')}`
            },
        })
            .then(response => {
                if (response.status === 401) {
                    throw new Error("Unauthorized: Please check your login credentials or token.");
                } else if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
            });
    },

    updatePost(id, content) {
        return fetch(`https://localhost:7119/post/${id}`, {
            method: "PUT",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('user')}`
            },
            body: JSON.stringify(content)
        })
            .then(response => {
                return response.json();
            });
    }
}

