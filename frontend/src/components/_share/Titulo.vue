<template>
  <div>
    <div style="display: flex; width: 505">
      <h2>{{ texto }}</h2>
      <div class="btn_voltar">
        <!-- Para receber o botão "Editar" por parâmetro no título, é necessário utilizar a tag <slot> -->
        <slot></slot>
        <button v-show="btnVoltar" class="btn btn_voltar_especifico" @click="voltar()">
          Voltar
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
    btnVoltar: Boolean,
  },
  methods: {
    voltar() {
      this.$router.back();
    },
  },
};
</script>

<style scoped>
.btn_voltar {
  width: 50%;
  position: absolute;
  margin-top: 15px;
}

.btn_voltar_especifico {
  float: right;
  background-color: rgb(199, 199, 199);
}
</style>
