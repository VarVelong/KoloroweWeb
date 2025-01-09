<template>
  <div v-if="$isLoggedIn()" id="middle-block" >
    <div class="inside-blocks">
      <h2>Opcje ofert</h2>
      <button class="button-orange" @click="$router.push({ name: 'offercreationpage' })">Stwórz Ofertę</button>
      <button class="button-orange" @click="$router.push({ name: 'offer' })">Zobacz Oferty</button>
      <p>Żeby dodać ofertę, kliknij "Stwórz Ofertę".</p>
      <p>Żeby usunąć ofertę, musisz kliknąć "Zobacz Oferty", po czym na stronie musisz kliknąć ikonkę śmietnika przy ofercie, którą chcesz usunąć.</p>
    </div>
    <div class="inside-blocks">
      <h2>Opcje aktualności</h2>
      <button class="button-orange" @click="$router.push({ name: 'postcreation' })">Stwórz Post</button>
      <button class="button-orange" @click="$router.push({ name: 'postcreation' })">Zobacz Posty</button>
      <p>Żeby dodać ofertę, kliknij "Stwórz Post".</p>
      <p>Żeby usunąć ofertę, musisz kliknąć "Zobacz Post", po czym na stronie musisz kliknąć ikonkę śmietnika przy poście, który chcesz usunąć.</p>
      <p>Żeby dokonać edycji posta, musisz kliknąć "Zobacz Post", po czym na stronie musisz kliknąć ikonkę edycji przy poście, który chcesz usunąć.</p>
    </div>
    <div class="inside-blocks">
      <h2>Opcje Galerii</h2>
      <button class="button-orange" @click="$router.push({ name: 'postcreation' })">Prześlij zdjęcie.</button>
      <button class="button-orange" @click="$router.push({ name: 'offer' })">Zobacz zdjęcia.</button>
      <p>Żeby dodać zdjęcie, kliknij "Prześlij zdjęcie", zostaniesz przeniesiony na stronę galerii, na której dole zobaczysz interfejs do przesłania zdjęcia.</p>
      <p>Żeby usunąć ofertę, musisz kliknąć "Zobacz Post", po czym na stronie musisz kliknąć ikonkę śmietnika przy poście, który chcesz usunąć.</p>
    </div>
    <div class="inside-blocks">
      <h2>Opcje kadry</h2>
      <button class="button-orange" @click="$router.push({ name: 'employees' })">Edytuj kadrę</button>
      <p>Żeby zmienić skład kady, kliknij "Edytuj kadrę", zostaniesz przeniesiony na stronę kadry przedszkola, po czym musisz kliknąć ikonkę edycji przy liście kadry, który chcesz edytować. </p>
    </div>
  </div>
</template>

<script>
</script>

<style scoped>
.inside-blocks {
  border: 3px solid #000000;
  border-radius: 20px;
  background-color: #ddd;
  padding: 15px;
  margin: 10px 0;
  border-radius: 50px;
  margin-bottom: 10px;
}

#middle-block {
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

.button-orange{
  margin: 15px;
}
</style>