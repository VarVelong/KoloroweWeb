export default {

    getPosts() {
        return fetch("https://localhost:7119/userpost", { method: "GET" })
            .then(response => {
                return response.json();
            });
    },

    createPost(data) {
        const formData = new FormData();
        formData.append('date', data.date.toISOString());
        formData.append('content', data.content);
        formData.append('image', data.image);
    
        return fetch("https://localhost:7119/userpost/post", {
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
    },

    createOffer(data) {
        formData.append('title', data.title);
        formData.append('content', data.content);

        debugger;
        return fetch("https://localhost:7119/offers", {
            method: "POST",
            headers: {
                'Accept': 'application/json', 
                Authorization: `Bearer ${localStorage.getItem('user')}`, 
            },
            body: formData,
        })
        .then(response => {
            if (response.status === 401) {
                throw new Error("Unauthorized: Please check your login credentials or token.");
            } else if (!response.ok) {
                throw new Error(`Error: ${response.statusText}`);
            }
            return response.json();
        });
    }
}

