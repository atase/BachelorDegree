const baseURL =  'http://localhost:5000/';

const ENDPOINTS = {
    giverGetAll: baseURL + 'giver/all',
    giverRegister: baseURL + 'giver/register',
    giverUpdate: baseURL + 'giver/update',
    giverInfo: baseURL + 'giver/info',
    giverDelete: baseURL + 'giver/delete',
    giverFilter: baseURL + 'giver/filter',
    receiverGetAll: baseURL + 'receiver/all',
    receiverRegister: baseURL + 'receiver/register',
    receiverUpdate: baseURL + 'receiver/update',
    receiverInfo: baseURL + 'receiver/info',
    receiverDelete: baseURL + 'receiver/delete',
    receiverFilter: baseURL + 'receiver/filter',
    compatibilityGivers: baseURL + 'compatibility/givers',
    compatibilityReceivers: baseURL + 'compatibility/receivers',
    compatibilityGiver: baseURL + 'compatibility/giver',
    compatibilityReceiver: baseURL + 'compatiblity/receiver',
    compatiblityScores: baseURL + 'compatibility/scores',
    matchingCompute: baseURL + 'matching/compute',
    compatibilityStatistics: baseURL + 'compatibility/statistics',
    compatibilityGenerateScores: baseURL + 'compatibility/generateScores' 
};