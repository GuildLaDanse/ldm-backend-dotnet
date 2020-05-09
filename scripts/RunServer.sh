#!/bin/bash

SCRIPTDIR=`dirname "$BASH_SOURCE"`

source ${SCRIPTDIR}/Functions.sh
source ${SCRIPTDIR}/Environment.sh

cd ${MAIN_PROJECT}

PrintSectionHeader "Running project"

exec dotnet exec ${RUNTIME_DLL}
