export default {

    getPosts() {
        return fetch("https://localhost:7119/userpost", { method: "GET" })
            .then(response => {
                return response.json();
            });
    },

    createPost(data) {
        return fetch("https://localhost:7119/userpost/post", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('user')}`
            },
            body: JSON.stringify(data)
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


    updatePost(date, content, image) {
        return fetch("https://localhost:7119/userpost", {
            method: "PATCH",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('user')}`
            },
            body: JSON.stringify({ date, content, image })
        })
            .then(response => {
                return response.json();
            });
    }
}

