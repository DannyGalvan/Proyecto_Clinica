import { loadImages } from "../../util/loadImages.js";

const Loading = () => {
  return (
    <div className="page-wrap d-flex flex-row align-items-center">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-8 col-md-4 col-sm-4">
            <img
              alt="Logo React"
              src={`${loadImages(`/react.svg`)}`}
              className="loading rounded img-fluid mb-5"
              width={450}
              height={450}
            />
            <h3 className="text-center fw-bold text-loading loading">
              Cargando... Espere
            </h3>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Loading;
