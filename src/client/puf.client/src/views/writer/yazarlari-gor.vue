<template>
  <div>
    <div class="main-content__top">
      <div class="alert alert-danger main-content__title">Writer Sayfası</div>
    </div>
    <div class="main-content__body">
      <div class="row">
        <div class="col-sm-12 col-md-4 mt-2 d-flex justify-content-center" v-for="p in writers" :key="p.id">
          <writer-card
            :fullname="p.displayName"
            :job="p.job"
            :description="p.description"
            :mailAddress="p.emailAddress"
          ></writer-card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import WriterCard from "../../components/cards/WriterCard.vue";
import axios from "axios";
export default {
  name: "yazarlari-gor",
  components: { WriterCard },
  data() {
    return {
      writers: [],
    };
  },
  mounted() {
    axios
      .get("https://localhost:5001/api/Management/Writer/list/10")
      .then((Response) => {
        this.writers = Response.data;
      });
  },
};
</script>