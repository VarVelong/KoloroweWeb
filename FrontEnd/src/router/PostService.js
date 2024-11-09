export default {

    getPosts() {
        return fetch("https://localhost:7119/userpost", { method: "GET" })
            .then(response => {
                return response.json();
            });
    },

    createPost(data) {
        debugger;
        return fetch("https://localhost:7119/userpost/post", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({post: data})
        })
        .then(response => {
            return response.json();
        });
    },

    updateSave(date, content, image) {
        return fetch("https://localhost:7119/userpost", {
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
    }


}