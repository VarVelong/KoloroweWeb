
const API_URL = 'https://localhost:7119/auth/';

class AuthService {
  // login(user) {
  // return axios
  //   .post(API_URL + 'login', {
  //     username: user.username,
  //     passwordHash: user.password,
  //   })
  //   .then(response => {
  //     if (response.data.token) {
  //       localStorage.setItem('user', JSON.stringify(response.data));
  //     }
  //     return response.data;
  //   });

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
      // if (response) {
      //   localStorage.setItem('user', JSON.stringify(response));
      // }
  
      return response.json();
    });
  }


  logout() {
    localStorage.removeItem('user');
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
