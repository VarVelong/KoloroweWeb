export default {
    getSaves() {
        return fetch("https://localhost:5173/userpost", { method: "GET" })
            .then(response => {
                return response.json();
            });
    },

    loadGame(saveId) {
        return fetch(`https://localhost:5173/userpost/${saveId}`, { method: "GET" })
            .then(response => {
                return response.json();
            });
    },

    updateSave(date, content, image) {
        return fetch("https://localhost:5173/userpost", {
            method: "PATCH",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({date, content, image })
        })
            .then(response => {
                return response.json();
            });
    },

    getPosts() {
        return fetch("https://localhost:5173/userpost", { method: "GET" })
            .then(response => {
                return response.json();
            });
    }
}