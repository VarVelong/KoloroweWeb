<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<template>

  <!-- <div v-if="$isLoggedIn()" class="status">Zalogowano jako Administrator.</div> -->

  <header>
    <div class="header-content">
      <img id="logo" src="../src/assets/logo.png" @click="$router.push('/')" />
      <nav>
        <div>
          <button :class="{ active: $route.name === 'about' }" @click="$router.push({ name: 'about' })">
            O nas
          </button>
          <button :class="{ active: $route.name === 'post-list' }" @click="$router.push({ name: 'post-list' })">
            Aktualności
          </button>
          <button :class="{ active: $route.name === 'offer' }" @click="$router.push({ name: 'offer' })">
            Oferta
          </button>
          <button :class="{ active: $route.name === 'employees' }" @click="$router.push({ name: 'employees' })">
            Kadra
          </button>
          <button :class="{ active: $route.name === 'contact' }" @click="$router.push({ name: 'contact' })">
            Kontakt
          </button>
          <button :class="{ active: $route.name === 'gallery' }" @click="$router.push({ name: 'gallery' })">
            Galeria
          </button>
        </div>
      </nav>
    </div>
  </header>

  <main class="row">
    <div class="col-md-3">
      <div id="left-background"></div>
    </div>
   
    <div class="col-md-6">
      <div class="col-sm-12">
        <RouterView />
      </div>
      <footer class="col-md-6">
        <p>&copy; 2024 Kolorowe Przedszkole.</p>
        <button v-if="$isLoggedIn()" @click="logout">logout</button>
      </footer>
    </div>
    <div class="col-md-3">
      <div id="right-background"></div>
    </div>
  </main>

</template>

<script>

export default {
  methods: {
    handleClick() {
    },
  },

  methods: {
    logout() {
      try {
        localStorage.removeItem('user');
        console.log('User has been logged out.');
        this.$router.go();
      } catch (error) {
        console.error('Error during logout:', error);
      }
    }
  }
};

</script>

<style scoped>
footer p {
  margin: 0;
}

.header-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.image-button img {
  max-height: 75px;
  margin-bottom: 5px;
  margin-top: 5px;
}

nav>div {
  display: flex;
  gap: 10px;
  list-style: none;
  padding: 0;
  margin: 0;
}

button {
  background: none;
  border: none;
  color: rgb(0, 0, 0);
  font-size: 16px;
  cursor: pointer;
  padding-bottom: 0;
  padding-top: 0;
}

button:hover {
  text-decoration: underline;
}

button.active {
  text-decoration: underline;
  font-weight: bold;
}

.status {
  margin-top: 10px;
  color: rgb(0, 0, 0);
  font-size: 14px;
  justify-content: left;
  bottom: 0;
  left: 0;
}
</style>
