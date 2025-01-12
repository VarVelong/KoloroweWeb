<template>
  <h1 class="page-title">O nas</h1>
  <div id="map"></div>
  <div id="about">
    <div id="about-container">
      <p>Przykładowe informacje o placówce.</p>
    </div>
  </div>
</template>

<script>
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

export default {
  mounted() {
    const map = L.map('map').setView([54.36102338196047, 18.55556593945651], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '© OpenStreetMap contributors',
    }).addTo(map);

    L.marker([54.36102338196047, 18.55556593945651]).addTo(map)
      .bindPopup('Kolorowe przedszkole jest tutaj!')
      .openPopup();
  },
};
</script>

<style scoped>
div {
  background-color: rgba(0, 0, 0, 0.5);
  width: 80%;
  border: 3px solid black;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  min-height: 100%;
}

h2 {
  color: black;
  font-size: 2em;
  margin-bottom: 10px;
  text-shadow: 1px 1px #FFD9E8;
}

p {
  font-size: 1.2em;
  line-height: 1.5;
  margin: 5px 0;
  color: black;
}

#about {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 100px;
}

#about-container {
  border: 3px solid black;
  border-radius: 15px;
  background-color: #ddd;
  margin: 15px;
  padding: 15px;
}

#map {
  height: 500px;
  width: 500px;
}
</style>