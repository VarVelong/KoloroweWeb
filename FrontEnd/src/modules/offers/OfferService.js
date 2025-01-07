const link = "https://localhost:7119/Offers";

class OfferService {
    fetchOffers() {
        return fetch(link, { method: "GET" })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                return response.json();
            });
    }

    createOffer(data) {
        return fetch(link, {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('user')}`,
            },
            body: JSON.stringify({ title: data.title, content: data.content })
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

    deleteOffer(id) {
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

export default new OfferService();