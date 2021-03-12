<template>
  <div>
    <b-form @submit.prevent="saveProduct">
      <b-form-group
        description="Pierwsza linia pod zdjeciem produktu."
        class="required"
        label="Nazwa Produktu:"
      >
        <b-form-input
          type="text"
          v-model="product.productName"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group label="Cena Produktu:">
        <b-form-input
          v-model="product.price"
          @keypress="onlyForCurrency"
          required
        ></b-form-input>
        <b-form-file
          class="mt-3"
          plain
          multiple
          accept="image/*"
          @change="uploadFile($event)"
        ></b-form-file>
        <div class="product-gallery">
          <b-img
            v-bind="firstImageProp"
            :src="firstImageSrc"
            :blank="firstImageBlank"
            class="mt-3 mr-1"
          />
          <b-img
            v-for="curImage in besidesFirst"
            v-bind="firstImageProp"
            v-bind:key="curImage.id"
            :src="curImage.fullFilePath"
            class="mt-3 mr-1"
          />
        </div>
        <div class="progress-bar-area">
          <b-progress
            v-for="img in uploadedImages"
            :key="img.id"
            :value="img.loadPercent"
            :max="100"
            show-progress
            :class="img.loadPercent"
            v-show="img.showProgress"
            animated
          ></b-progress>
        </div>
        <div class="editor-container">
          <quill-editor
            ref="myTextEditor"
            v-model="product.productDescription"
            :config="editorOption"
          >
          </quill-editor>
        </div>
        <b-button type="submit" variant="primary" class="mt-3">Submit</b-button>
      </b-form-group>
    </b-form>
  </div>
</template>

<script>
class imageUploadDto {
  constructor() {
    this.loadPercent = 0;
    this.showProgress = true;
  }
}
class addedImageDto {
  constructor(id, isMain) {
    this.ProductImageId = id;
    this.IsMainImage = isMain;
  }
}
import "quill/dist/quill.core.css";
import "quill/dist/quill.snow.css";
import "quill/dist/quill.bubble.css";
import ProductServices from "../services/ProductServices";
import { quillEditor } from "vue-quill-editor";
// import { Drag, DropList } from "vue-easy-dnd";
import Vue from "vue";
export default {
  components: {
    quillEditor
  },
  data() {
    return {
      product: {
        id: null,
        Price: 0,
        ProductName: "",
        Images: []
      },
      uploadedImages: [],
      firstImageProp: {
        blankColor: "#A9A9A9",
        height: 130,
        width: 156
      },
      editorOption: {}
    };
  },
  computed: {
    firstImageSrc: {
      get() {
        let firstImg = this.uploadedImages.find(
          img => img.showProgress === false
        );
        if (firstImg === undefined || firstImg.fullFilePath === undefined) {
          return "";
        } else {
          return this.uploadedImages.find(img => img.showProgress === false)
            .fullFilePath;
        }
      }
    },
    firstImageBlank: {
      get() {
        return this.firstImageSrc === "";
      }
    },
    besidesFirst: {
      get() {
        return this.uploadedImages.filter(
          img => !img.showProgress && img.id > 0
        );
      }
    }
  },
  methods: {
    onlyForCurrency($event) {
      // console.log($event.keyCode); //keyCodes value
      let keyCode = $event.keyCode ? $event.keyCode : $event.which;
      if (
        (keyCode < 48 || keyCode > 57) &&
        (keyCode !== 46 || this.product.price.indexOf(".") != -1)
      ) {
        // 46 is dot
        $event.preventDefault();
      }

      // restrict to 2 decimal places
      if (
        this.product.price != null &&
        this.product.price.indexOf(".") > -1 &&
        this.product.price.split(".")[1].length > 1
      ) {
        $event.preventDefault();
      }
    },
    uploadFile($event) {
      $event.target.files.forEach(file => {
        var newUpload = new imageUploadDto();

        if (this.uploadedImages) {
          newUpload.id = this.uploadedImages.length;
        } else {
          newUpload.id = 0;
        }
        console.log(newUpload);
        this.uploadedImages.push(newUpload);
        // newUpload.fileName = file.
        ProductServices.postImage(file, newUpload, this.updateUploadStatus);
      });
      //
    },
    updateUploadStatus(statusDto) {
      var currElement = this.uploadedImages[statusDto.id];
      Vue.set(currElement, "fullFilePath", statusDto.fullFilePath);
      Vue.set(currElement, "ProductImageId", statusDto.ProductImageId);
      Vue.set(currElement, "loadPercent", statusDto.loadPercent);
      // console.log(statusDto);
      if (statusDto.loadPercent == 100) {
        setTimeout(() => {
          Vue.set(currElement, "showProgress", false);
        }, 3000);
      }
    },
    saveProduct() {
      this.product.Images = [];
      this.uploadedImages.forEach(image => {
        let imageDto = new addedImageDto(image.ProductImageId, image.id === 0);
        this.product.Images.push(imageDto);
      });
      ProductServices.createProduct(this.product).then(response => {
        const status = response.status;
        if (status == 200) {
          this.$router.push("/");
          console.log("sukces");
        } else {
          console.log("fail - nigdzie nie idziesz");
        }
      });
    }
  }
};
</script>

<style scoped></style>
