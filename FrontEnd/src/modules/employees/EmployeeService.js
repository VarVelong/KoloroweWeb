const link = "https://localhost:7119/Employees"

export default {

    fetchEmployees() {
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
    },

    updateEmployee(groupName, content) {
        return fetch(`${link}/${groupName}`, {
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

