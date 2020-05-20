<template>
  <div>
    <titulo :texto="`Aluno: :${aluno.nome}`" :btnVoltar="modo_edicao">
      <button
        v-show="!modo_edicao"
        class="btn btn_editar"
        @click="editarAluno()"
      >
        Editar
      </button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="!modo_edicao">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="!modo_edicao">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="!modo_edicao">{{ aluno.dataNascimento }}</label>
            <input v-else v-model="aluno.dataNascimento" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="!modo_edicao">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="modo_edicao">
        <button class="btn btn_salvar" @click="salvar()">Salvar</button>
        <button class="btn btn_cancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  component: {
    Titulo,
  },
  data() {
    return {
      aluno: {},
      professores: [],
      idAluno: this.$route.params.id,
      modo_edicao: false,
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/alunos/" + this.idAluno)
      .then((ret) => ret.json())
      .then((aluno) => (this.aluno = aluno));

    this.$http
      .get("http://localhost:5000/api/professores")
      .then((res) => res.json())
      .then((professor) => (this.professores = professor));
  },
  methods: {
    editarAluno() {
      this.modo_edicao = !this.modo_edicao;
    },
    salvar() {
        let _alunoEditado = {
            id: this.aluno.id,
            nome: this.aluno.nome,
            sobrenome: this.aluno.sobrenome,
            dataNascimento: this.aluno.dataNascimento,
            professor:  this.aluno.professor
        },

        this.$http.put(`http://localhost:5000/api/alunos/${this.aluno.id}`, this.aluno);
        this.modo_edicao = !this.modo_edicao;

    },
    cancelar() {
      this.modo_edicao = !this.modo_edicao;
    }
  },
};
</script>

<style scoped>
.btn_editar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btn_salvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btn_cancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}

.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  font-family: Montserrat;
  border-radius: 5px;
  border: 1px solid silver;
  background-color: rgb(245, 245, 245);
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}
</style>
