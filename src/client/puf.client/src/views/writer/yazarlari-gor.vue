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
            :instagramUrl="p.instagram"
            :facebookUrl="p.facebook"
            :githubUrl="p.github"
            :city="p.city"
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
      writer:{
        id: "",
        displayName: "",
        job:"",
        description:"",
        city:"",
        emailAddress:"",
        instagram:"",
        facebook:"",
        twitter:"",
        linkedin:"",
        github:"",
        photoAddress:""

      }
    };
  },
  mounted() {
    axios
      .get(process.env.VUE_APP_API_URL + "/Management/Writer/list/10")
      .then((Response) => {
        Response.data.forEach(w => {
            var writer = {
              id : w.id,
              displayName : w.displayName,
              job : w.job,
              description : w.description,
              emailAddress : w.emailAddress,
              city : w.city,
              instagram : checkAccount(w.socialAccounts, 'Instagram'),
              facebook : checkAccount(w.socialAccounts, 'Facebook'),
              linkedin : checkAccount(w.socialAccounts, 'LinkedIn'),
              twitter : checkAccount(w.socialAccounts, 'Twitter'),
              github : checkAccount(w.socialAccounts, 'GitHub')
            };
            this.writers.push(writer);
        });
      });
  },
};

function checkAccount(socialAccounts, account){
      for (var i = 0; i< socialAccounts.length; i++) {
        if (socialAccounts[i].name == account) {
          return socialAccounts[i].url;
        }
      }
    }
</script>