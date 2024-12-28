<template>
    <body>
        <div>
            <h2>Opcje ofert</h2>
            <button @click="$router.push({ name: 'offercreationpage'})">Stwórz Ofertę</button>
            <button @click="$router.push({ name: 'offer'})">Zobacz Oferty</button>
            <p>instrukcja</p>
        </div>
        <div>
            <h2>Opcje aktualności</h2>
            <button @click="$router.push({ name: 'postcreation'})">Stwórz Post</button>
            <p>instrukcja</p>
        </div>
        <div>
            <h2>Opcje Galerii</h2>
            <button @click="$router.push({ name: 'postcreation'})">Stwórz Post</button>
            <p>instrukcja</p>
        </div>
        <div>
            <h2>Zarejestruj nowe konto</h2>
            <button @click="$router.push({ name: 'register' })">Register</button>
            <p>instrukcja</p>
        </div>
    </body>
</template>

<script>

// export default{
//     mounted: {
//         this.$router.go();
//     }
// }

</script>

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

h2 {
  color: #FF6F61; 
  font-size: 2em;
  margin-bottom: 10px;
  text-shadow: 1px 1px #FFD9E8;
}

p {
  font-size: 1.2em;
  line-height: 1.5;
  margin: 5px 0;
  color: #555; 
}
</style>