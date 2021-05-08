<template>
  <div class="image-flip">
    <div class="mainflip flip-0">
      <div class="frontside">
        <div class="card">
          <div class="card-body text-center">
            <p>
              <img class="img-fluid" :src="profilePhoto" alt="card image" />
            </p>
            <h4 class="card-title">{{ fullname }}</h4>
            <p class="card-text">
              {{ city }}
            </p>
            
            <i class="fas fa-exchange-alt" style="color: blue"></i>
          </div>
        </div>
      </div>
      <div class="backside">
        <div class="card">
          <div class="card-body text-center mt-4">
            <h4 class="card-title">{{ job }}</h4>
            
            <p class="card-text">
              {{ description }}
            </p>
            <ul class="list-inline">
              <li class="list-inline-item" v-if="instagramUrl != null">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="instagramUrl"
                >
                  <i class="fab fa-instagram"></i>
                </a>
              </li>
              <li class="list-inline-item" v-if="facebookUrl != null">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="facebookUrl"
                >
                  <i class="fab fa-facebook"></i>
                </a>
              </li>
              <li class="list-inline-item" v-if="twitterUrl != null">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="twitterUrl"
                >
                  <i class="fab fa-twitter"></i>
                </a>
              </li>
              <li class="list-inline-item" v-if="linkedinUrl != null">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="linkedinUrl"
                >
                  <i class="fab fa-linkedin"></i>
                </a>
              </li>
              <li class="list-inline-item" v-if="githubUrl != null">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="githubUrl"
                >
                  <i class="fab fa-github"></i>
                </a>
              </li>
              <li class="list-inline-item">
                <a
                  class="social-icon text-xs-center"
                  target="_blank"
                  :href="'mailto:' + mailAddress"
                  title="mail gönder"
                >
                  <i class="fas fa-paper-plane"></i>
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "person",
  props: {
    fullname: {
      type: String,
      required: true,
    },
    job: {
      type: String,
    },
    description: {
      type: String,
      required: true,
    },
    city: {
      type: String,
      required: true,
    },
    instagramUrl: {
      type: String,
    },
    linkedinUrl: {
      type: String,
    },
    githubUrl: {
      type: String,
    },
    facebookUrl: {
      type: String,
    },
    twitterUrl: {
      type: String,
    },
    mailAddress: {
      type: String,
    },
    photo: {
      type: String,
    },
  },
  computed: {
    profilePhoto: function () {
      if (this.photo) {
        return this.photo;
      }
      return "/img/_user.jpg";
    },

  },
};
</script>

<style>
.btn-primary:hover,
.btn-primary:focus {
  background-color: #108d6f;
  border-color: #108d6f;
  box-shadow: none;
  outline: none;
}

.btn-primary {
  color: #fff;
  background-color: #007b5e;
  border-color: #007b5e;
}

.card {
  border: none !important;
  background: #ffffff;
}

.image-flip:hover .backside,
.image-flip.hover .backside {
  -webkit-transform: rotateY(0deg);
  -moz-transform: rotateY(0deg);
  -o-transform: rotateY(0deg);
  -ms-transform: rotateY(0deg);
  transform: rotateY(0deg);
  border-radius: 0.25rem;
}

.image-flip:hover .frontside,
.image-flip.hover .frontside {
  -webkit-transform: rotateY(180deg);
  -moz-transform: rotateY(180deg);
  -o-transform: rotateY(180deg);
  transform: rotateY(180deg);
}

.mainflip {
  -webkit-transition: 1s;
  -webkit-transform-style: preserve-3d;
  -ms-transition: 1s;
  -moz-transition: 1s;
  -moz-transform: perspective(1000px);
  -moz-transform-style: preserve-3d;
  -ms-transform-style: preserve-3d;
  transition: 1s;
  transform-style: preserve-3d;
  position: relative;
}

.frontside {
  position: relative;
  -webkit-transform: rotateY(0deg);
  -ms-transform: rotateY(0deg);
  z-index: 2;
  margin-bottom: 30px;
}

.backside {
  position: absolute;
  top: 0;
  left: 0;
  background: white;
  -webkit-transform: rotateY(-180deg);
  -moz-transform: rotateY(-180deg);
  -o-transform: rotateY(-180deg);
  -ms-transform: rotateY(-180deg);
  transform: rotateY(-180deg);
  -webkit-box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
  -moz-box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
  box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
}

.frontside,
.backside {
  -webkit-backface-visibility: hidden;
  -moz-backface-visibility: hidden;
  -ms-backface-visibility: hidden;
  backface-visibility: hidden;
  -webkit-transition: 1s;
  -webkit-transform-style: preserve-3d;
  -moz-transition: 1s;
  -moz-transform-style: preserve-3d;
  -o-transition: 1s;
  -o-transform-style: preserve-3d;
  -ms-transition: 1s;
  -ms-transform-style: preserve-3d;
  transition: 1s;
  transform-style: preserve-3d;
}

.frontside .card,
.backside .card {
  height: 350px;
  width: 400px;
}

.backside .card a {
  font-size: 18px;
  color: #007b5e !important;
}

.frontside .card .card-title,
.backside .card .card-title {
  color: #007b5e !important;
}

.frontside .card .card-body img {
  width: 120px;
  height: 120px;
  border-radius: 50%;
}
</style>