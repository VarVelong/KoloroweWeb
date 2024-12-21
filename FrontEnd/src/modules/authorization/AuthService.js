const API_URL = 'https://localhost:7119/auth/';

class AuthService {
  login(user) {
    return fetch(API_URL + 'login', {
      method: "POST",
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        username: user.username,
        passwordHash: user.password
      })
    })
    .then(response => {
      return response.json();
    });
  }

  logout() {
    try {
      localStorage.removeItem('user', token);
      console.log('User has been logged out.');
    } catch (error) {
      console.error('Error during logout:', error);
    }
  }

  register(user) {
    return fetch(API_URL + 'register', {
      method: "POST",
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        username: user.username,
        passwordHash: user.password
      })
    })
      .then(response => {
        return response.json();
      });
  }
}

export default new AuthService();
