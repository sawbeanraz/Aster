export default function buildContractor() {
    return function makeContractor({
        id,
        firstName
        lastName,
        dob,
        address,
    } = {}) {
        if(!id) { 
            throw new Error('Contractor must have valid id');
        }

        if(!firstName) {
            throw new Error('Contractor must have valid name');
        }

        if(!lastName) {
            throw new Error('Contractor must have valid name');
        }
    }
}