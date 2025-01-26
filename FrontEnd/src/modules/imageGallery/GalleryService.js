const link= "https://localhost:7119/gallery";

class GalleryService {
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
    }

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
    }

    async deleteImage(id){
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

export default new GalleryService();