const BASE_URL= "https://localhost:7119/gallery";

export default {
    
    getImage(id) {
        return fetch(`${BASE_URL}/${id}`, { method: "GET" })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    },

    createImage(data) {
        const formData = new FormData();
        formData.append('image', data.image);
    
        return fetch(`${BASE_URL}/`, {
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

    fetchImages(page) {
        let link = page ? `${BASE_URL}/?page=${page}` : `${BASE_URL}/`;
        return fetch(link, {
            method: "GET"})
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

