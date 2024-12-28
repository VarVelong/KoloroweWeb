const link= "https://localhost:7119/gallery";

export default {
    
    getImage(id) {
        return fetch(`${link}/${id}`, { method: "GET" })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    createImage(data) {
        const formData = new FormData();
        formData.append('image', data);
        return fetch(`${link}/`, {
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
    },

    createPost(data) {
        const formData = new FormData();
        formData.append('date', data.date.toISOString());
        formData.append('content', data.content);
        formData.append('image', data.image);

        return fetch(link, {
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

    async fetchImages(page) {
        let fullLink = page ? `${link}/?page=${page}` : `${link}/`;
        return await fetch(fullLink, {
            method: "GET"})
            .then(response => {
                if (response.status === 401) {
                    throw new Error("Unauthorized: Please check your login credentials or token.");
                } else if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    async deleteImage(id){
        debugger;
        return fetch(`${link}/${id}`, {
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
    }
}

