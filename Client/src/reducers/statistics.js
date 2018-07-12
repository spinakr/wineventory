const GET_STATISTICS_REQUEST = "statistics/GET_STATISTICS_REQUEST";
const GET_STATISTICS_SUCCESS = "statistics/GET_STATISTICS_SUCCESS";

const initialState = {
  statisticsRequestPending: false,
  wineCount: 0
};

export default (state = initialState, action) => {
  switch (action.type) {
    case GET_STATISTICS_REQUEST:
      return {
        ...state,
        statisticsRequestPending: true
      };
    case GET_STATISTICS_SUCCESS:
      return {
        ...state,
        statisticsRequestPending: false,
        wineCount: action.payload.wineCount
      };
    default:
      return initialState;
  }
};
