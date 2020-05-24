<template>
  <div>
    <titulo texto="Sobre" :btn_voltar="true"/>
    <p>
      Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum tempora
      praesentium, quisquam voluptatum debitis id placeat blanditiis cum, enim
      minima suscipit dolorum vero recusandae distinctio sint dolor maiores quos
      veritatis!
    </p>
    <p>
      Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam sunt amet
      illo quia atque! Minima quia facilis pariatur nihil quas expedita, odit
      sit deleniti similique illo? Soluta, voluptate! Quam, veniam?
    </p>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo,
  },
};
</script>

<style lang="scss" scoped></style>
