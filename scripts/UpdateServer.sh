#!/bin/bash

SCRIPTDIR=`dirname "$BASH_SOURCE"`

source ${SCRIPTDIR}/Functions.sh
source ${SCRIPTDIR}/Environment.sh

PrintSectionHeader "Pulling updates from Git"

git pull

cd src/App

PrintSectionHeader "Cleaning project"

dotnet clean

PrintSectionHeader "Restoring packages"

dotnet restore

PrintSectionHeader "Building project"

dotnet build

PrintSectionHeader "Running database updates"

dotnet ef database update