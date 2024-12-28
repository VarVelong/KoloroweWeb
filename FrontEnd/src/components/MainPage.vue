<template>
    <body>
        <div class="main">
            <h1>Witamy w kolorowym przedszkolu</h1>
            <button id="a-button" @click="$router.push({ name: 'offer'})">Zobacz naszą ofertę</button>
            <button id="a-button" @click="$router.push({ name: 'contact'})">Umów wizytę</button>
        </div>
    </body>
</template>

<style scoped>
div {
  background-color: #FFF9C4; 
  border: 3px solid #FFD54F;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center; 
}
</style>


