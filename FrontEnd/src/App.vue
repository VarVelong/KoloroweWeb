<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<template>
  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  </head>

  <header>
    <button @click="$router.push('/')" class="image-button">
      <img src="../src/assets/logo.png"/>
    </button>
    <nav>
        <ul>
            <button @click="$router.push({ name: 'about'})">O nas</button>
            <button @click="$router.push({ name: 'update'})">Aktualności</button>
            <button @click="$router.push({ name: 'offer'})">Oferta</button>
            <button @click="$router.push({ name: 'personnel'})">Kadra</button>
            <button @click="$router.push({ name: 'contact'})">Kontakt</button>
        </ul>
    </nav>
  </header>

  <RouterView />

  <footer>
    <p>&copy; 2024 Kolorowe Przedszkole.</p>
  </footer>

</template>

<script>

export default {
  methods: {
    handleClick() {
    },},};

</script>

<style scoped>
#app {
  padding: 0px !important;
  max-width: none;
}

header {
    background: #4CAF50;
    color: white;
    padding: 10px 20px;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

nav ul {
    list-style: none;
    display: flex;
    gap: 15px;
}

nav a {
    color: white;
    text-decoration: none;
}

div {
    padding: 20px;
    margin: 10px;
}

.program {
    border: 1px solid #ccc;
    padding: 10px;
    margin: 10px 0;
}

footer {
    background: #333;
    color: white;
    text-align: center;
    padding: 10px;
    position: relative;
    bottom: 0;
    width: 100%;
}

.image-button {
  border: none;
  background: none;
  padding: 0;
  cursor: pointer;
}
</style>
